function getSubsequence(array) {
    let maxNum = Number.MIN_SAFE_INTEGER;
    let result = [];

    for (let i = 0; i < array.length; i++) {
        
        if (array[i] >= maxNum) {
            maxNum = array[i];
            result.push(maxNum);
        }       
    }

    return result;
}

console.log(getSubsequence([20, 
    3, 
    2, 
    15,
    6, 
    1]));