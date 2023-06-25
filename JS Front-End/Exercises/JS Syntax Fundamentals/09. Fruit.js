function BuyFruit(kind, grams, pricePerKG) {
    const kg = grams / 1000;
    const price = kg * pricePerKG;
    console.log(`I need $${price.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${kind}.`);
}