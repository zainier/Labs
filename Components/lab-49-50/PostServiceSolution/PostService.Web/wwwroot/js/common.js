// Спільні для всіх сторінок функції: меню навігації, форматування, повідомлення.

/** Назви типів доставки для відображення користувачу. */
export const deliveryTypeText = Object.freeze({
    Department: "Відділення",
    Courier: "Кур'єр",
    ExpressCourier: "Експрес-кур'єр"
});

/** Форматує число в українському стилі (кома як десятковий роздільник); null → «—». */
export function formatNumber(value) {
    return value === null || value === undefined ? "—" : value.toLocaleString("uk-UA", { useGrouping: false });
}

export function showAlert(element, message) {
    element.textContent = message;
    element.hidden = false;
}

export function hideAlert(element) {
    element.textContent = "";
    element.hidden = true;
}

/** Кнопка меню на вузькому екрані відкриває та закриває список посилань навігації. */
function initMenu() {
    const header = document.querySelector(".site-header");
    const toggle = header?.querySelector(".menu-toggle");

    if (!toggle) {
        return;
    }

    toggle.addEventListener("click", () => {
        const isOpen = header.classList.toggle("menu-open");
        toggle.setAttribute("aria-expanded", String(isOpen));
        toggle.innerHTML = isOpen ? "&#10005;" : "&#9776;";
    });
}

initMenu();
