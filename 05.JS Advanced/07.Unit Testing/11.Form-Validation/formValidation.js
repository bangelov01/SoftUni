function validate() {

    let usernameElment = document.querySelector(`#username`);
    let emailElement = document.querySelector(`#email`);
    let passwordElement = document.querySelector(`#password`);
    let confirmPasswordElement = document.querySelector(`#confirm-password`);
    let isCompanyElement = document.querySelector(`#company`);
    let submitButton = document.querySelector(`#submit`);

    document.querySelector(`#company`).addEventListener(`change`, (e) => {

        let info = document.querySelector(`#companyInfo`);

        info.style.display = info.style.display === "none" ? "block" : "none";
    
    });

    submitButton.addEventListener(`click`, (event) => {
        event.preventDefault();

        let validElements = [];
        let userneameValidateRegex = /^[a-zA-Z0-9]{3,20}$/
        let passwordValidateRegex = /^\w{5,15}$/
        let emailValidateRegex = /^[^@.]+@[^@]*\.[^@]*$/  ///^\w+\@\w+\.\w+$/

        let isValidUsername = userneameValidateRegex.test(usernameElment.value);
        let isValidPassword = passwordValidateRegex.test(passwordElement.value);
        let isValidConfirmPassword = passwordValidateRegex.test(confirmPasswordElement.value);
        let isValidEmail = emailValidateRegex.test(emailElement.value);

        setBorder(usernameElment, isValidUsername, validElements);
        setBorder(emailElement, isValidEmail, validElements);

        if ((passwordElement.value === confirmPasswordElement.value) &&
        (isValidPassword) && 
        (isValidConfirmPassword)) {

            passwordElement.style.border = "none";
            confirmPasswordElement.style.border = "none";
            validElements.push(true);
        }
        else{
            
            passwordElement.style.borderColor = "red";
            confirmPasswordElement.style.borderColor = "red";
            validElements.push(false);
        }

        if (isCompanyElement.checked == true) {
            
            let companyNumberElement = document.querySelector(`#companyNumber`);

            if (companyNumberElement.value < 1000 || companyNumberElement.value > 9999) {
                companyNumberElement.style.borderColor = "red";
                validElements.push(false);
            }
            else{
                companyNumberElement.style.border = "none";
                validElements.push(true);
            }
        }

        if (!validElements.includes(false)) {
            document.querySelector(`#valid`).style.display = "block";
        }
        else{
            document.querySelector(`#valid`).style.display = "none";
        }

        function setBorder(element, validation, result) {

            if (!validation) {

                element.style.borderColor = "red";
                result.push(false);
            }
            else{
                element.style.border = "none";
                result.push(true);
            }
        }
    });
}
