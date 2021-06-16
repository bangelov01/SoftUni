function validate() {
    
    let emailElement = document.querySelector(`#email`);

    let validateRegex = /^[a-z]+\@[a-z]+\.[a-z]+$/;

    emailElement.addEventListener(`change`, () => {

        if (!validateRegex.test(emailElement.value)) {
            emailElement.classList.add(`error`);
        }
        else{
            emailElement.classList.remove(`error`);
        }
    });
}