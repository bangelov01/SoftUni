function getElements(input) {   
    return input.filter((a,b) => b % 2 !== 0).map(x => x * 2).reverse().join(` `);
}

console.log(getElements([10, 15, 20, 25]));
