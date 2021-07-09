function attachEvents() {
    
    const baseUrl = `http://localhost:3030/jsonstore/phonebook/`;

    document.getElementById(`btnLoad`).addEventListener(`click`, async() => {

        const response = await fetch(baseUrl);
        const phones = await response.json();

        const ul = document.getElementById(`phonebook`);
        ul.innerHTML = ``;

        Object.values(phones).forEach(el => {

            let li = document.createElement(`li`);
            li.setAttribute(`data-id`, `${el._id}`)
            li.textContent = `${el.person}: ${el.phone}`;
            let button = document.createElement(`button`)
            button.textContent = `Delete`;
            button.classList.add(`delPhoneNum`)
            li.appendChild(button);
            ul.appendChild(li);
        });

    });

    document.getElementById(`phonebook`).addEventListener(`click`, async(e) => {
        
        if (e.target.className !== `delPhoneNum`) {
            return;
        }

        let urlId = baseUrl + e.target.parentElement.dataset.id;

        await fetch(urlId, {method: `delete`});

        e.target.parentElement.remove();
    });

    document.getElementById(`btnCreate`).addEventListener(`click`, async() => {

        const personValue = document.getElementById(`person`).value;
        const phoneValue = document.getElementById(`phone`).value;

        if (personValue == `` || phoneValue == ``) {
            return alert(`Fields should not be empty!`);
        }

        const response = await fetch(baseUrl, {
            method: `post`,
            headers: {"Content-Type": `application/json`},
            body: JSON.stringify({person: personValue, phone: phoneValue})
        });

        if (!response.ok) {
            const error = await response.json();
            return alert(error.message);
        }

        document.getElementById(`person`).value = ``;
        document.getElementById(`phone`).value = ``;

    });
}

attachEvents();