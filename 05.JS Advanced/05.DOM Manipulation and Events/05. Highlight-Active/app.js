function focused() {
    let inputFieldElements = document.querySelectorAll(`input`);

    let inputElmentsArray = Array.from(inputFieldElements);

    inputElmentsArray.forEach(x => {
        x.addEventListener(`focus`, () => {
            x.parentElement.classList.add("focused");
        });
        x.addEventListener(`blur`, () => {
            x.parentElement.classList.remove(`focused`);
        })
    })
}