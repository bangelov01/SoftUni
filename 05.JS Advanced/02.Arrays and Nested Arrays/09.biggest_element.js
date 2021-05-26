function findBiggest(matrix) {

    let maxNum = Number.MIN_SAFE_INTEGER;

    for (const array of matrix) {
        
        for (const int of array) {
            
            if (int > maxNum) {
                maxNum = int;
            }
        }
    }

    return maxNum;
}

findBiggest([[20, 50, 10],
    [8, 33, 145]])