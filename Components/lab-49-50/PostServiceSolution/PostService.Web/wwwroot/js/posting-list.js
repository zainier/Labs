// Сторінка списку поштових відправлень: завантаження, вибір, редагування, видалення.
import { postingApi } from "./api.js";
import { deliveryTypeText, formatNumber, showAlert, hideAlert } from "./common.js";

const rowsElement = document.getElementById("postings-rows");
const cardsElement = document.getElementById("postings-cards");
const emptyElement = document.getElementById("empty");
const alertElement = document.getElementById("alert");
const editButton = document.getElementById("edit-button");
const deleteButton = document.getElementById("delete-button");

const confirmOverlay = document.getElementById("confirm");
const confirmText = document.getElementById("confirm-text");
const confirmOkButton = document.getElementById("confirm-ok");
const confirmCancelButton = document.getElementById("confirm-cancel");

let postings = [];
let selectedId = null;
let loadFailed = false;

function getSelectedPosting() {
    return postings.find((posting) => posting.id === selectedId) ?? null;
}

function createElement(tag, className, text) {
    const element = document.createElement(tag);

    if (className) {
        element.className = className;
    }

    if (text !== undefined) {
        element.textContent = text;
    }

    return element;
}

function renderTable() {
    rowsElement.replaceChildren(...postings.map((posting) => {
        const row = document.createElement("tr");
        row.classList.toggle("selected", posting.id === selectedId);

        const cells = [
            [posting.from, ""],
            [posting.to, ""],
            [posting.content, ""],
            [deliveryTypeText[posting.deliveryType] ?? posting.deliveryType, ""],
            [formatNumber(posting.weight), "num"],
            [formatNumber(posting.value), "num"],
            [formatNumber(posting.price), "num"]
        ];

        for (const [text, className] of cells) {
            row.append(createElement("td", className, text));
        }

        row.addEventListener("click", () => select(posting.id));
        return row;
    }));
}

function renderCards() {
    cardsElement.replaceChildren(...postings.map((posting) => {
        const isSelected = posting.id === selectedId;
        const card = createElement("div", isSelected ? "card selected" : "card");

        const mainRow = createElement("div", "card-row main");
        mainRow.append(
            createElement("span", "", `${posting.from} → ${posting.to}`),
            createElement("span", "", `${formatNumber(posting.price)} грн`));

        const extraRow = createElement("div", "card-row extra");
        extraRow.append(
            createElement("span", "", `${posting.content} · ${deliveryTypeText[posting.deliveryType] ?? posting.deliveryType}`),
            createElement("span", "", `${formatNumber(posting.weight)} кг`));

        card.append(mainRow, extraRow);

        if (isSelected) {
            const actions = createElement("div", "card-actions");
            const edit = createElement("button", "btn", "Редагувати");
            const remove = createElement("button", "btn danger", "Видалити");
            edit.type = remove.type = "button";
            edit.addEventListener("click", (event) => { event.stopPropagation(); editSelected(); });
            remove.addEventListener("click", (event) => { event.stopPropagation(); askDeleteSelected(); });
            actions.append(edit, remove);
            card.append(actions);
        }

        card.addEventListener("click", () => select(posting.id));
        return card;
    }));
}

function render() {
    renderTable();
    renderCards();

    emptyElement.hidden = postings.length > 0 || loadFailed;
    editButton.disabled = deleteButton.disabled = getSelectedPosting() === null;
}

function select(id) {
    selectedId = id;
    render();
}

async function loadPostings() {
    try {
        postings = await postingApi.getAll();
        loadFailed = false;
        hideAlert(alertElement);
    } catch (error) {
        postings = [];
        loadFailed = true;
        showAlert(alertElement, error.message);
    }

    if (getSelectedPosting() === null) {
        selectedId = null;
    }

    render();
}

function editSelected() {
    const posting = getSelectedPosting();

    if (posting) {
        window.location.href = `posting-edit.html?id=${posting.id}`;
    }
}

function askDeleteSelected() {
    const posting = getSelectedPosting();

    if (!posting) {
        return;
    }

    confirmText.textContent = `Видалити відправлення ${posting.from} → ${posting.to}? Цю дію не можна скасувати.`;
    confirmOverlay.hidden = false;
    confirmCancelButton.focus();
}

function closeConfirm() {
    confirmOverlay.hidden = true;
}

async function deleteSelected() {
    const posting = getSelectedPosting();
    closeConfirm();

    if (!posting) {
        return;
    }

    let errorMessage = null;

    try {
        await postingApi.remove(posting.id);
    } catch (error) {
        if (error.status === 0) {
            showAlert(alertElement, error.message);
            return;
        }

        errorMessage = error.message;
    }

    selectedId = null;
    await loadPostings();

    if (errorMessage) {
        showAlert(alertElement, errorMessage);
    }
}

editButton.addEventListener("click", editSelected);
deleteButton.addEventListener("click", askDeleteSelected);
confirmCancelButton.addEventListener("click", closeConfirm);
confirmOkButton.addEventListener("click", deleteSelected);
document.addEventListener("keydown", (event) => {
    if (event.key === "Escape" && !confirmOverlay.hidden) {
        closeConfirm();
    }
});

loadPostings();
