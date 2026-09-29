const value1Input = document.getElementById("value1");
const value2Input = document.getElementById("value2");
const resultElement = document.getElementById("result");
const historyList = document.getElementById("history");

function calculate() {
    const a = Number(value1Input.value);
    const b = Number(value2Input.value);
    const sum = a + b;

    resultElement.textContent = sum;

    const historyItem = document.createElement("li");
    historyItem.textContent = a + " + " + b + " = " + sum;
    historyList.appendChild(historyItem);
}
