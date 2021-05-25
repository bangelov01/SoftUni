function fibonacci(n,k) {

    let arr = [1];

    for (let i = 1; i < n; i++) {
        
        let startIndex = Math.max(0, i - k);
        let currentElement = arr.slice(startIndex, startIndex + k).reduce((a,b) => a + b,0);
        arr.push(currentElement);        
    }

    let result = arr.map(x => Number(x));

    return result;
}

console.log(fibonacci(9,5));