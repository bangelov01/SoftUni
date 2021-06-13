function calculator() {
    
    let calculate = {};

    return {
        init: (selector1, selector2, resultSelector) => {
            calculate[`firstNumber`] = document.querySelector(`${selector1}`);
            calculate[`secondNumber`] = document.querySelector(`${selector2}`);
            calculate[`result`] = document.querySelector(`${resultSelector}`);
        },
        add: () => {
            calculate.result.value = Number(calculate.firstNumber.value) 
            + Number(calculate.secondNumber.value);

        },
        subtract: () => {
            let number2 = Number(calculate.firstNumber.value);
            let number1 = Number(calculate.secondNumber.value);

            let result = (number2) - (number1);

            // calculate.result.value = Number(calculate.secondNumber.value) 
            // - Number(calculate.firstNumber.value);
        }
    }
}

const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result');




