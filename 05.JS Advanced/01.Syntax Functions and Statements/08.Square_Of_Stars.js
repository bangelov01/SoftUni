
function printSquare(input) {

    if (typeof (input) !== 'number') {
        input = 5;
    }

    let matrix = [];
    let result = '';

    for (let i = 0; i < input; i++) {
        matrix[i] = [];

        for (let j = 0; j < input; j++) {
            matrix[i][j] = '*';
            if (j == input - 1) {
                result += '*';
            }
            else{
                result += '* ';
            }
        }
        console.log(result);
        result = '';
    }
}