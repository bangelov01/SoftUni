function solution() {

    let string = ``;

    return {
        append(input) {
            string += input;
        },
        removeStart(input) {
            string = string.slice(input);
        },
        removeEnd(input) {
            string = string.slice(0,string.length - input);
        },
        print() {
            console.log(string);
        }
    }
}



let secondZeroTest = solution();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();