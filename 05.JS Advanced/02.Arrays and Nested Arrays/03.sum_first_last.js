function sum(input) {
     return Number(input.shift()) + Number(input.pop());
}

console.log(sum(['5', '10']));