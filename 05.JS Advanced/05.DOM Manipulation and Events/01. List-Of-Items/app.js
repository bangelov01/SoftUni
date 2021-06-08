function addItem() {
    let inputTextElement = document.getElementById(`newItemText`);

    let newListItemElement = document.createElement(`li`);
    newListItemElement.textContent = inputTextElement.value;

    document.querySelector(`#items`).appendChild(newListItemElement);

    inputTextElement.value = ``;
}