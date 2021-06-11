// let add = (() => {
//     let total = 0;
//     return function sum(num) {
//         total += num;
//         sum.toString = () => total;
//         return sum;
//     }
// })();

function add(input) {

    let total = input;

    return function sum(num) {
        total += num;
        sum.toString = () => total;
        return sum;
    }  
}

console.log(add(1)(6)(-3).toString());