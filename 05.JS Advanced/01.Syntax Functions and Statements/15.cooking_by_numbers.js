function getResult(num, op1, op2, op3, op4, op5) {
    
    let number = Number(num);

    for (let i = 1; i < arguments.length; i++) {
        
        let result = operationExecute(number, arguments[i]);
        console.log(result);
        
        number = result;
    }

    function operationExecute(number, operation) {
        
        let result = 0;

        switch (operation) {
            case `chop`:
                result = number /= 2;
                break;
            case `dice`:
                result = Math.sqrt(number);
                break;
            case `spice`:
                result = number + 1;
                break;
            case `bake`:
                result = number *= 3;
                break;
            case `fillet`:
                result = number *= 0.80;
                break;
        }

        return result;
    }
}

getResult('9', 'dice', 'spice', 'chop', 'bake', 'fillet')