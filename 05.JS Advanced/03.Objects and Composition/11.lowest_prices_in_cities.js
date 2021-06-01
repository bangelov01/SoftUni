function getPrice(input) {
    
    let products = {};

    for (let index = 0; index < input.length; index++) {
        let [town, product, price] = input[index].split(` | `);
        price = Number(price);

        if (!products.hasOwnProperty(product)) {
            products[product] = {};
        }
        
        products[product][town] = price;
    }

    let result = [];

    for (const key in products) {
        let townsSorted = Object.entries(products[key]).sort((a,b) => a[1] - b[1]);
        let cheapestTown = townsSorted[0];
        result.push(`${key} -> ${cheapestTown[1]} (${cheapestTown[0]})`)

    }

    console.log(result.join(`\n`));
}

console.log(getPrice(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']));


