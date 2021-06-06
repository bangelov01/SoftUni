function solve() {

    let selectMenuToOptionElement = document.querySelector(`#selectMenuTo option`);
    selectMenuToOptionElement.setAttribute(`value`, `binary`);
    selectMenuToOptionElement.textContent = `Binary`;

    let newOptionElement = document.createElement(`option`)
    newOptionElement.setAttribute(`value`, `hexadecimal`);
    newOptionElement.textContent = `Hexadecimal`;

    document.querySelector(`#selectMenuTo`).appendChild(newOptionElement);

    document.querySelector(`button`).addEventListener(`click`, () => {

        let selectedElement = document.getElementById(`selectMenuTo`);
        let inputElement = document.getElementById(`input`).value;

        if (selectedElement.value === `binary`) {
            document.querySelector(`#result`).value = converToBinary(inputElement);
        }
        else{
            document.querySelector(`#result`).value = convertToHexadecimal(inputElement);
        }
    });


    function converToBinary(number){

        let num = parseInt(number);

        return result = num.toString(2);
    }

    function convertToHexadecimal(number){

        let num = parseInt(number);

        return result = num.toString(16).toUpperCase();
    }
}