function getMatrix(input) {
    
    let matrix = input.map(x => x.map(y => Number(y)));

    let baseSum = matrix[0].reduce((a,b) => a + b);
    let rowSum = 0;
    let colSum = 0;
    let isMagical = true;

    for (let row = 0; row < matrix.length; row++) {     
        rowSum = matrix[row].reduce((a,b) => a + b);

        for (let col = 0; col < matrix.length; col++) {         
            colSum += matrix[col][row];  
        }

        if (baseSum !== rowSum || baseSum !== colSum) {
            return isMagical = false;
        }     
        colSum = 0;
    }

    return isMagical;
}

console.log(getMatrix([[1, 0, 0],
    [0, 1, 0]]));
