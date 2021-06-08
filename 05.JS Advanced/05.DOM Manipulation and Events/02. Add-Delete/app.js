function addItem() {
    let newTextElement = document.getElementById(`newItemText`).value;
    let listElement = document.getElementById(`items`);

    if (newTextElement.length === 0) {
        return;
    };

    let listItem = document.createElement(`li`);
    listItem.textContent = newTextElement;

    let removeElement = document.createElement(`a`);
    let linkText = document.createTextNode(`[Delete]`);

    removeElement.appendChild(linkText);
    removeElement.href = `#`;
    removeElement.addEventListener(`click`, () =>{
        listItem.remove();
    });

    listItem.appendChild(removeElement);
    listElement.appendChild(listItem);
}