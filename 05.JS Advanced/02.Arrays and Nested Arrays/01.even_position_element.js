function findElements(input) {
    let result = [];
    for (let index = 0; index < input.length; index+=2) {
        
        result.push(input[index]);
    }

    return result.join(` `);
}

console.log(findElements([20,30,40,50,60]));