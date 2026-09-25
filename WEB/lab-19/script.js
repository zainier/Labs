function calculateAverage(studentGrades) {
    let sum = 0;

    for (let i = 0; i < studentGrades.length; i++) {
        if (typeof studentGrades[i] !== 'number') {
            throw new Error('Усі елементи масиву повинні бути числами.');
        }

        if (studentGrades[i] < 0 || studentGrades[i] > 100) {
            throw new Error('Оцінки повинні бути в діапазоні від 0 до 100.');
        }

        sum += studentGrades[i];
    }

    return sum / studentGrades.length;
}

function renderResult(message) {
    const resultsList = document.getElementById('results');
    const item = document.createElement('li');
    item.textContent = message;
    resultsList.appendChild(item);
}

function testCalculateAverage(studentGrades) {
    const input = `Вхідні дані: ${JSON.stringify(studentGrades)}`;
    try {
        const average = calculateAverage(studentGrades);
        const message = `${input} → Середня оцінка: ${average}`;
        console.log(message);
        renderResult(message);
    } catch (error) {
        const message = `${input} → ${error.message}`;
        console.error(message);
        renderResult(message);
    }
}

// 1. Валідний масив оцінок
const validGrades = [85, 90, 78, 92, 88];
testCalculateAverage(validGrades);

// 2. Некоректний тип елемента (приклад із завдання)
const nonNumberGrades = [85, 90, 78, 92, 88, 'A'];
testCalculateAverage(nonNumberGrades);

// 3. Оцінка менша за 0
const belowRangeGrades = [85, 90, -5, 92, 88];
testCalculateAverage(belowRangeGrades);

// 4. Оцінка більша за 100
const aboveRangeGrades = [85, 90, 78, 105, 88];
testCalculateAverage(aboveRangeGrades);
