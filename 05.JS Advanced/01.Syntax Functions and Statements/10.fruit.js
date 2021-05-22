function calculatePrice(fruitType, weightGrams, priceKg) {

    let weightKg = weightGrams / 1000;

    let price = weightKg * priceKg;

    console.log(`I need $${price.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${fruitType}.`)
    
}