// Сторінка редагування поштового відправлення: edit.html?id=N
const SERVICE_URL = "http://localhost:8080/postings";
const LIST_PAGE = "index.html";
const MAX_DEPARTMENT_WEIGHT = 20;

const form = document.getElementById("posting-form");
const alertElement = document.getElementById("alert");
const saveButton = document.getElementById("save-button");
const cancelButton = document.getElementById("cancel-button");

// Відправлення, завантажене із сервера для редагування.
let loadedPosting = null;

// Значення числового поля: null — поле порожнє, NaN — введено не число.
function readNumber(field) {
    if (field.validity.badInput) {
        return NaN;
    }

    return field.value === "" ? null : Number(field.value);
}

// Правила перевірки полів (ті самі, що в PostService). Повертають текст помилки або "".
const rules = {
    from: (field) => field.value.trim().length >= 2
        ? "" : "Відправник має містити щонайменше 2 символи",
    to: (field) => field.value.trim().length >= 2
        ? "" : "Отримувач має містити щонайменше 2 символи",
    content: (field) => field.value.trim() !== ""
        ? "" : "Вкажіть вміст відправлення",
    deliveryType: (field) => field.value !== ""
        ? "" : "Оберіть тип доставки",
    weight: (field) => {
        const weight = readNumber(field);

        if (!(weight > 0)) {
            return "Введіть вагу числом, більшим за 0";
        }

        if (form.elements.deliveryType.value === "Department" && weight > MAX_DEPARTMENT_WEIGHT) {
            return `Для доставки у відділення вага не може перевищувати ${MAX_DEPARTMENT_WEIGHT} кг`;
        }

        return "";
    },
    width: (field) => readNumber(field) > 0 ? "" : "Введіть ширину числом, більшим за 0",
    height: (field) => readNumber(field) > 0 ? "" : "Введіть висоту числом, більшим за 0",
    depth: (field) => readNumber(field) > 0 ? "" : "Введіть глибину числом, більшим за 0",
    value: (field) => {
        const value = readNumber(field);
        return value === null || value >= 0 ? "" : "Оголошена цінність не може бути від'ємною";
    }
};

const fieldNames = Object.keys(rules);

function showError(field, message) {
    const errorElement = document.getElementById(`${field.id}-error`);

    field.classList.add("invalid");
    errorElement.textContent = message;
    errorElement.hidden = false;
}

function hideError(field) {
    const errorElement = document.getElementById(`${field.id}-error`);

    field.classList.remove("invalid");
    errorElement.textContent = "";
    errorElement.hidden = true;
}

// Перевіряє одне поле: показує помилку або знімає її. Повертає true, якщо дані коректні.
function validateField(field) {
    const message = rules[field.name](field);

    if (message) {
        showError(field, message);
        return false;
    }

    hideError(field);
    return true;
}

function showAlert(message) {
    alertElement.textContent = message;
    alertElement.hidden = false;
}

function hideAlert() {
    alertElement.textContent = "";
    alertElement.hidden = true;
}

// Помилки, які повернув сервер (HTTP 400), показуються біля відповідних полів.
function showServerErrors(errors) {
    const otherMessages = [];

    for (const [name, messages] of Object.entries(errors)) {
        const field = form.elements[name];

        if (field && fieldNames.includes(name)) {
            showError(field, messages.join(" "));
        } else {
            otherMessages.push(...messages);
        }
    }

    if (otherMessages.length > 0) {
        showAlert(otherMessages.join(" "));
    }
}

function fillForm(posting) {
    form.elements.from.value = posting.from;
    form.elements.to.value = posting.to;
    form.elements.content.value = posting.content;
    form.elements.deliveryType.value = posting.deliveryType;
    form.elements.weight.value = posting.weight;
    form.elements.width.value = posting.width;
    form.elements.height.value = posting.height;
    form.elements.depth.value = posting.depth;
    form.elements.value.value = posting.value ?? "";
}

function readForm() {
    return {
        id: loadedPosting.id,
        from: form.elements.from.value.trim(),
        to: form.elements.to.value.trim(),
        content: form.elements.content.value.trim(),
        deliveryType: form.elements.deliveryType.value,
        weight: readNumber(form.elements.weight),
        width: readNumber(form.elements.width),
        height: readNumber(form.elements.height),
        depth: readNumber(form.elements.depth),
        value: readNumber(form.elements.value),
        price: loadedPosting.price,
        description: loadedPosting.description
    };
}

// --- Обробники подій полів -------------------------------------------------

for (const name of fieldNames) {
    const field = form.elements[name];

    // change: перевірка введених даних.
    field.addEventListener("change", () => {
        validateField(field);

        // Обмеження ваги залежить від типу доставки, тож після його зміни перевіряємо й вагу.
        if (name === "deliveryType" && form.elements.weight.value !== "") {
            validateField(form.elements.weight);
        }
    });

    // input: під час введення ховаємо повідомлення про помилку й знімаємо підсвітку.
    field.addEventListener("input", () => hideError(field));
}

// --- Кнопки ----------------------------------------------------------------

saveButton.addEventListener("click", async () => {
    hideAlert();

    const fields = fieldNames.map((name) => form.elements[name]);
    const results = fields.map(validateField);

    if (results.includes(false)) {
        fields.find((field) => field.classList.contains("invalid")).focus();
        return;
    }

    saveButton.disabled = true;

    try {
        const response = await fetch(`${SERVICE_URL}/${loadedPosting.id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(readForm())
        });

        if (response.status === 400) {
            const problem = await response.json().catch(() => null);
            showServerErrors(problem?.errors ?? { "": ["Сервер відхилив дані відправлення."] });
            return;
        }

        if (response.status === 404) {
            showAlert("Відправлення вже відсутнє на сервері.");
            return;
        }

        if (!response.ok) {
            showAlert(`Не вдалося зберегти зміни: сервер повернув помилку ${response.status}.`);
            return;
        }

        window.location.href = LIST_PAGE;
    } catch {
        showAlert("Не вдалося з'єднатися із сервером. Перевірте, чи запущено PostService.");
    } finally {
        saveButton.disabled = false;
    }
});

cancelButton.addEventListener("click", () => {
    window.location.href = LIST_PAGE;
});

// --- Завантаження відправлення ----------------------------------------------

async function loadPosting() {
    const id = new URLSearchParams(window.location.search).get("id");

    if (!id) {
        showAlert("Не вказано відправлення для редагування.");
        return;
    }

    try {
        const response = await fetch(`${SERVICE_URL}/${encodeURIComponent(id)}`);

        if (response.status === 404) {
            showAlert("Відправлення не знайдено.");
            return;
        }

        if (!response.ok) {
            showAlert(`Не вдалося завантажити відправлення: сервер повернув помилку ${response.status}.`);
            return;
        }

        loadedPosting = await response.json();
        fillForm(loadedPosting);
        saveButton.disabled = false;
    } catch {
        showAlert("Не вдалося з'єднатися із сервером. Перевірте, чи запущено PostService.");
    }
}

loadPosting();
