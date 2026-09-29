"use strict";

// Завдання 1. Підключення скрипта та перетворення типів
console.log("=== Завдання 1. Перетворення типів ===");

let result;

result = "10" + 5;
console.log('"10" + 5 =', result, "| тип:", typeof result);

result = "10" - 5;
console.log('"10" - 5 =', result, "| тип:", typeof result);

result = "10" * "2";
console.log('"10" * "2" =', result, "| тип:", typeof result);

result = 10 + true;
console.log("10 + true =", result, "| тип:", typeof result);

result = 10 + false;
console.log("10 + false =", result, "| тип:", typeof result);

result = Number("125 грн");
console.log('Number("125 грн") =', result, "| тип:", typeof result);

result = Number("");
console.log('Number("") =', result, "| тип:", typeof result);

result = Boolean("false");
console.log('Boolean("false") =', result, "| тип:", typeof result);

result = Boolean("");
console.log('Boolean("") =', result, "| тип:", typeof result);

// Завдання 2. Розрахунок вартості замовлення та ПДВ
console.log("=== Завдання 2. Вартість замовлення та ПДВ ===");

const orderItems = [
    { name: "Клавіатура", price: 750, quantity: 2 },
    { name: "Миша", price: 300, quantity: 3 },
    { name: "Монітор", price: 5200, quantity: 1 },
];

const VAT_RATE = 0.2;

function ItemCostCalculator(price, quantity) {
    return price * quantity;
}

function OrderSumCalculator(items, vatRate, vatReport) {
    let total = 0;
    for (const item of items) {
        const cost = ItemCostCalculator(item.price, item.quantity);
        const vat = cost * vatRate;
        vatReport.push({ name: item.name, vat: vat });
        total += cost + vat;
    }
    return total;
}

const vatReport = [];
const orderTotal = OrderSumCalculator(orderItems, VAT_RATE, vatReport);

console.log("Загальна вартість замовлення:", orderTotal);
console.log(vatReport);
