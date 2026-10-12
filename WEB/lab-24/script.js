"use strict";

class Parcel {
  #weight;
  static #count = 0;

  constructor(recipient, weight, length, width, height) {
    this.recipient = recipient;
    this.length = length;
    this.width = width;
    this.height = height;
    this.weight = weight;
    Parcel.#count++;
  }

  get weight() {
    return this.#weight;
  }

  set weight(value) {
    if (typeof value !== "number" || Number.isNaN(value) || value <= 0) {
      throw new Error("Вага відправлення має бути додатним числом");
    }
    this.#weight = value;
  }

  get volumetricWeight() {
    return this.length * this.width * this.height / 5000;
  }

  get chargeableWeight() {
    return Math.max(this.weight, this.volumetricWeight);
  }

  describe() {
    return `Відправлення для ${this.recipient}: фактична вага ${this.weight} кг, ` +
           `об'ємна вага ${this.volumetricWeight.toFixed(2)} кг, ` +
           `розрахункова вага ${this.chargeableWeight.toFixed(2)} кг`;
  }

  static getCount() {
    return Parcel.#count;
  }
}

class ParcelPriceCalculator {
  constructor(ratePerKg) {
    this.ratePerKg = ratePerKg;
  }

  calculate(parcel) {
    return parcel.chargeableWeight * this.ratePerKg;
  }

  getName() {
    return "Базовий тариф";
  }
}

class PostOfficeParcelPriceCalculator extends ParcelPriceCalculator {
  constructor() {
    super(15);
  }

  getName() {
    return "Відділення пошти";
  }
}

class CourierParcelPriceCalculator extends ParcelPriceCalculator {
  constructor() {
    super(30);
  }

  getName() {
    return "Кур'єрська доставка";
  }
}

class ExpressParcelPriceCalculator extends ParcelPriceCalculator {
  constructor() {
    super(30);
    this.expressRatePerKg = 25;
  }

  calculate(parcel) {
    return super.calculate(parcel) + parcel.chargeableWeight * this.expressRatePerKg;
  }

  getName() {
    return "Експрес-доставка";
  }
}

const parcels = [
  new Parcel("Іван Петренко", 5, 20, 15, 10),
  new Parcel("Олена Коваль", 1, 40, 30, 25)
];

const calculators = [
  new PostOfficeParcelPriceCalculator(),
  new CourierParcelPriceCalculator(),
  new ExpressParcelPriceCalculator()
];

for (const parcel of parcels) {
  console.log(parcel.describe());
  for (const calculator of calculators) {
    console.log(`  ${calculator.getName()}: ${calculator.calculate(parcel).toFixed(2)} грн`);
  }
  console.log("");
}

console.log(`Усього створено відправлень: ${Parcel.getCount()}`);
