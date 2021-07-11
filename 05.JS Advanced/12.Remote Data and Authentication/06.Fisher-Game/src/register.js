document.getElementById(`register-form`).addEventListener(`submit`, async(e) => {
    
    e.preventDefault();
    const formData = new FormData(e.target);

    const email = formData.get(`email`);
    const password = formData.get(`password`);
    const rePass = formData.get(`rePass`);

    if (email == `` || password == ``) {
        return alert(`All fields are required!`)
    }
    else if (password != rePass) {
        return alert(`Passwords must match!`)
    }

    const response = await fetch(`http://localhost:3030/users/register`, {
        method: `post`,
        headers: {"Content-Type": `application/json`},
        body: JSON.stringify({email, password})
    });

    if (!response.ok) {
        const error = await response.json();
        e.target.reset();
        return alert(error.message);
    }
    const data = await response.json();
    sessionStorage.setItem(`userToken`, data.accessToken);

    e.target.previousElementSibling.style.display = `none`;
    e.target.style.display = `none`;
    e.target.reset();

    window.location.pathname = `./index.html`;

    return alert(`Registration successful!`);
});