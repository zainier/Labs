// Сторінка списку поштових відправлень.
const SERVICE_URL = "http://localhost:8080/postings";

const DELIVERY_TYPE_TEXT = {
    Department: "Відділення",
    Courier: "Кур'єр",
    ExpressCourier: "Експрес-кур'єр"
};

const statusElement = document.getElementById("status");
const tableBody = document.getElementById("postings");

function createCell(text, className) {
    const cell = document.createElement("td");
    cell.textContent = text;

    if (className) {
        cell.className = className;
    }

    return cell;
}

function renderTable(postings) {
    tableBody.innerHTML = "";

    for (const posting of postings) {
        const row = document.createElement("tr");

        row.append(
            createCell(posting.from),
            createCell(posting.to),
            createCell(posting.content),
            createCell(DELIVERY_TYPE_TEXT[posting.deliveryType] ?? posting.deliveryType),
            createCell(posting.weight, "number"),
            createCell(posting.value ?? "—", "number"),
            createCell(posting.price, "number"));

        const editCell = document.createElement("td");
        const editLink = document.createElement("a");
        editLink.href = `edit.html?id=${posting.id}`;
        editLink.textContent = "Редагувати";
        editCell.append(editLink);
        row.append(editCell);

        tableBody.append(row);
    }
}

async function refresh() {
    try {
        const response = await fetch(SERVICE_URL);

        if (!response.ok) {
            throw new Error(`сервер повернув помилку ${response.status}`);
        }

        const postings = await response.json();
        renderTable(postings);
        statusElement.textContent = `Завантажено відправлень: ${postings.length}`;
    } catch (error) {
        const reason = error instanceof TypeError ? "немає з'єднання із сервером" : error.message;
        statusElement.textContent = `Не вдалося завантажити дані: ${reason}`;
    }
}

document.addEventListener("DOMContentLoaded", refresh);
