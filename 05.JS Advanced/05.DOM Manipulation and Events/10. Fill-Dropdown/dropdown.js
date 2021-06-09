function addItem() {
    let newItemTextElement = document.querySelector(`#newItemText`);
    let newItemValueElement = document.querySelector(`#newItemValue`);
    let selectElement = document.getElementById(`menu`);

    let createOptionElment = document.createElement(`option`);
    createOptionElment.textContent = newItemTextElement.value;
    createOptionElment.value = newItemValueElement.value;
    selectElement.appendChild(createOptionElment);

    newItemTextElement.value = ``;
    newItemValueElement.value = ``;
}