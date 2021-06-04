function subtract() {
    
    let num1Element = document.querySelector(`#firstNumber`).value;
    let num2Element = document.querySelector(`#secondNumber`).value;

    let sum = Number(num1Element) - Number(num2Element);

    document.querySelector(`#result`).textContent = sum;

}