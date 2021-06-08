function validate() {
    let inputElement = document.getElementById(`email`);

    inputElement.addEventListener(`change`, (e) => {
        let reg = new RegExp(/^[a-z]+[@][a-z]+[.][a-z]+$/gm);

        if (reg.test(e.currentTarget.value)) {
            e.currentTarget.removeAttribute(`class`);
        }
        else{
            
            e.currentTarget.className = `error`;
        }
    })
}