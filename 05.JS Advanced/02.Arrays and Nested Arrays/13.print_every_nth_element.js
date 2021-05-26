function print(array, num) {
    const result = [];

    for (let i = 0; i < array.length; i+= num) {
        result.push(array[i]);     
    }

    return result;
}
console.log(print(['dsa',
'asd', 
'test', 
'tset'], 
2
));