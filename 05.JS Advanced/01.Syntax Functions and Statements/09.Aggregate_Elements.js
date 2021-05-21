function calculation(arr) {
    
    let sumResult = arr.reduce((a, b) => a + b);

    let inverseValuesSum = 0;

    for (const item of arr) {

        inverseValuesSum += 1/item;
    }
    console.log(sumResult);
    console.log(inverseValuesSum.toFixed(4));
    console.log(arr.join(''));
}

calculation([1,2,3])