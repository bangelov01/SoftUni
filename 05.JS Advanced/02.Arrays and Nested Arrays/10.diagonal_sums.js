function diagonalSums(matrix) {
    const numMatrix = matrix.map(x => x.map(y => Number(y)));

    let firstDiagonal = 0;
    let secondDiagonal = 0;

    let firstIndex = 0;
    let secondIndex = numMatrix[0].length - 1;

    numMatrix.forEach(x => {
        firstDiagonal += x[firstIndex++];
        secondDiagonal += x[secondIndex--];
    });

    console.log(firstDiagonal + ` ` + secondDiagonal);
}

diagonalSums([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]])