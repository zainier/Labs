// Спільна форма створення (posting-edit.html) та редагування (posting-edit.html?id=N) відправлення.
import { postingApi, ValidationError } from "./api.js";
import { formatNumber, showAlert, hideAlert } from "./common.js";

const MAX_DEPARTMENT_WEIGHT = 20;
const MIN_NAME_LENGTH = 2;

const form = document.getElementById("posting-form");
const titleElement = document.getElementById("page-title");
const alertElement = document.getElementById("alert");
const saveButton = document.getElementById("save-button");
const priceInput = document.getElementById("price");

const fieldNames = ["from", "to", "content", "deliveryType", "weight", "value", "width", "height", "depth"];

/** Запис, завантажений для редагування; null — створення нового відправлення. */
let originalPosting = null;

/** Перетворює введений текст на число (кома або крапка); "" → null, некоректний текст → NaN. */
function parseNumber(text) {
    const trimmed = text.trim().replace(",", ".");
    return trimmed === "" ? null : Number(trimmed);
}

function readForm() {
    const data = new FormData(form);
    return Object.fromEntries(fieldNames.map((name) => [name, String(data.get(name) ?? "")]));
}

/** Перевіряє дані за правилами PostService. Повертає { поле: повідомлення }. */
function validate(raw) {
    const errors = {};

    if (raw.from.trim().length < MIN_NAME_LENGTH) {
        errors.from = `Відправник має містити щонайменше ${MIN_NAME_LENGTH} символи`;
    }

    if (raw.to.trim().length < MIN_NAME_LENGTH) {
        errors.to = `Отримувач має містити щонайменше ${MIN_NAME_LENGTH} символи`;
    }

    if (raw.content.trim() === "") {
        errors.content = "Вкажіть вміст відправлення";
    }

    if (raw.deliveryType === "") {
        errors.deliveryType = "Виберіть тип доставки";
    }

    const weight = parseNumber(raw.weight);

    if (!(weight > 0)) {
        errors.weight = "Введіть вагу числом, більшим за 0";
    } else if (raw.deliveryType === "Department" && weight > MAX_DEPARTMENT_WEIGHT) {
        errors.weight = `Для доставки у відділення вага не може перевищувати ${MAX_DEPARTMENT_WEIGHT} кг`;
    }

    const dimensions = { width: "ширину", height: "висоту", depth: "глибину" };

    for (const [name, accusative] of Object.entries(dimensions)) {
        if (!(parseNumber(raw[name]) > 0)) {
            errors[name] = `Введіть ${accusative} числом, більшим за 0`;
        }
    }

    const value = parseNumber(raw.value);

    if (value !== null && !(value >= 0)) {
        errors.value = "Введіть цінність числом, не меншим за 0";
    }

    return errors;
}

function setFieldError(name, message) {
    const field = form.querySelector(`[data-field="${name}"]`);
    const errorElement = document.getElementById(`${name}-error`);

    field.classList.toggle("invalid", Boolean(message));
    errorElement.textContent = message ?? "";
    errorElement.hidden = !message;
}

function showErrors(errors) {
    for (const name of fieldNames) {
        setFieldError(name, errors[name] ?? null);
    }

    const firstInvalid = fieldNames.find((name) => errors[name]);

    if (firstInvalid) {
        document.getElementById(firstInvalid).focus();
    }
}

function toPosting(raw) {
    return {
        from: raw.from.trim(),
        to: raw.to.trim(),
        content: raw.content.trim(),
        deliveryType: raw.deliveryType,
        weight: parseNumber(raw.weight),
        width: parseNumber(raw.width),
        height: parseNumber(raw.height),
        depth: parseNumber(raw.depth),
        value: parseNumber(raw.value)
    };
}

function fillForm(posting) {
    const toText = (number) => (number === null ? "" : formatNumber(number));

    form.elements.from.value = posting.from;
    form.elements.to.value = posting.to;
    form.elements.content.value = posting.content;
    form.elements.deliveryType.value = posting.deliveryType;
    form.elements.weight.value = toText(posting.weight);
    form.elements.value.value = toText(posting.value);
    form.elements.width.value = toText(posting.width);
    form.elements.height.value = toText(posting.height);
    form.elements.depth.value = toText(posting.depth);
    priceInput.value = formatNumber(posting.price);
}

/** Помилки сервера (ValidationProblem) показуються біля полів, решта — у загальному повідомленні. */
function showServerErrors(fieldErrors) {
    const errors = {};
    const other = [];

    for (const [name, messages] of Object.entries(fieldErrors)) {
        if (fieldNames.includes(name)) {
            errors[name] = messages[0];
        } else {
            other.push(...messages);
        }
    }

    showErrors(errors);

    if (other.length > 0) {
        showAlert(alertElement, other.join("\n"));
    }
}

async function onSubmit(event) {
    event.preventDefault();
    hideAlert(alertElement);

    const raw = readForm();
    const errors = validate(raw);
    showErrors(errors);

    if (Object.keys(errors).length > 0) {
        return;
    }

    const posting = toPosting(raw);
    saveButton.disabled = true;

    try {
        if (originalPosting) {
            await postingApi.update(originalPosting.id, {
                ...posting,
                id: originalPosting.id,
                price: originalPosting.price,
                description: originalPosting.description
            });
        } else {
            await postingApi.create(posting);
        }

        window.location.href = "postings.html";
    } catch (error) {
        if (error instanceof ValidationError) {
            showServerErrors(error.fieldErrors);
        } else {
            showAlert(alertElement, error.message);
        }

        saveButton.disabled = false;
    }
}

async function init() {
    form.addEventListener("submit", onSubmit);

    // Помилку поля знімаємо, щойно користувач почав його виправляти.
    form.addEventListener("input", (event) => {
        if (fieldNames.includes(event.target.name)) {
            setFieldError(event.target.name, null);
        }
    });

    const idParameter = new URLSearchParams(window.location.search).get("id");

    if (idParameter === null) {
        return;
    }

    titleElement.textContent = "Редагування відправлення";
    document.title = "PostService — Редагування відправлення";
    saveButton.disabled = true;

    const id = Number(idParameter);

    if (!Number.isInteger(id)) {
        showAlert(alertElement, "Відправлення не знайдено.");
        return;
    }

    try {
        originalPosting = await postingApi.getById(id);
        fillForm(originalPosting);
        saveButton.disabled = false;
    } catch (error) {
        showAlert(alertElement, error.message);
    }
}

init();
