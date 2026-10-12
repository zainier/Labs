const SERVICE_URL = "http://localhost:5000/postings";

const statusElement = document.getElementById("status");

async function loadData() {
    const response = await fetch(SERVICE_URL);
    if (!response.ok) {
        throw new Error("Сервер повернув помилку: " + response.status);
    }
    return await response.json();
}

function createCell(fieldName, model) {
    const cell = document.createElement("td");
    cell.textContent = model[fieldName];
    return cell;
}

function renderTable(data) {
    const tableBody = document.getElementById("postings");
    const tableHeader = document.getElementById("table-header");
    tableBody.innerHTML = "";

    const columns = tableHeader.querySelectorAll("th");
    for (const posting of data) {
        const row = document.createElement("tr");
        for (const column of columns) {
            const fieldName = column.getAttribute("x-column");
            row.appendChild(createCell(fieldName, posting));
        }
        tableBody.appendChild(row);
    }
}

async function refresh() {
    try {
        const postings = await loadData();
        console.log(postings);
        renderTable(postings);
        statusElement.textContent = "Завантажено відправлень: " + postings.length;
    } catch (error) {
        statusElement.textContent = "Не вдалося завантажити дані: " + error.message;
        console.error(error);
    }
}

document.addEventListener("DOMContentLoaded", refresh);
