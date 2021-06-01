function orderProducts(input) {
    
    let products = {};
    let initial = [];

    for (let i = 0; i < input.length; i++) {
        let [productName, productPrice] = input[i].split(` : `);
        productPrice = Number(productPrice);

        if (!products.hasOwnProperty(productName)) {
            products[productName] = productPrice;
        }
        
        initial.push(productName[0].toUpperCase());
    }

    let capitals = initial.filter((value, index, arr) => arr.indexOf(value) === index)
        .sort((a, b) => a.localeCompare(b));

    let keys = Object.keys(products).sort((a,b) => a.localeCompare(b));

    let result = [];

    for (let j = 0; j < capitals.length; j++) {

        result.push(capitals[j]);

        for (const key of keys) {
            if (capitals[j] !== key[0]) {
                break;
            }
            result.push(`  ${key}: ${products[key]}`)
        }
        
        keys = keys.filter(value => {
            if (value[0] !== capitals[j]) {
                return value;
            }
        });
    }

    return result.join(`\n`);
}

orderProducts(['Banana : 2',
'Rubic s Cube : 5',
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10']
);