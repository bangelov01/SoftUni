function lockedProfile() {
    
    let buttons = document.querySelectorAll(`#main .profile button`);

    for (let i = 0; i < buttons.length; i++) {
        
        buttons[i].addEventListener(`click`, () => {
            let radioButtonName = `user${i + 1}Locked`;
            let radioButton = document.querySelector(`input[name="${radioButtonName}"]:checked`);

            if (radioButton.value === `unlock`) {
                let hiddenElement = document.getElementById(`user${i + 1}HiddenFields`);
                hiddenElement.style.display = hiddenElement.style.display === `block` ? `none` : `block`;
                buttons[i].textContent = buttons[i].textContent === `Show more` ? `Hide it` : `Show more`;
            }
        });
    }
}