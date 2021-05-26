function findPairs(matrix) {
    
    let numOfPairs = 0;

    for (let i = 0; i < matrix[0].length; i++) {
        
        for (let j = 0; j < matrix.length - 1; j++) {
            
            if (matrix[j][i] == matrix[j + 1][i]) {
                numOfPairs++;
            }          
        }      
    }

    for (let k = 0; k < matrix.length; k++) {
        
        for (let m = 0; m < matrix[k].length - 1; m++) {
            
            if (matrix[k][m] == matrix[k][m + 1]) {
                numOfPairs++;
            }          
        }     
    }

    console.log(numOfPairs);
}

findPairs([[2,2, 5, 7, 4],
    [4, 0, 5, 3, 4],
    [2, 5, 5, 4, 2]])