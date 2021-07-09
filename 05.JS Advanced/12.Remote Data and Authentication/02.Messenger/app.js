function attachEvents() {

    const url = `http://localhost:3030/jsonstore/messenger`;

    document.getElementById(`submit`).addEventListener(`click`, async () => {

        const nameValue = document.querySelector(`input[name="author"]`).value;
        const messageValue = document.querySelector(`input[name="content"]`).value;

        if (nameValue == `` || messageValue == ``) {
            return alert(`Fields should not be empty!`);
        }

        const response = await fetch(url, {
            method: `post`,
            headers: { "Content-Type": `application/json` },
            body: JSON.stringify({ author: nameValue, content: messageValue })
        });

        if (!response.ok) {
            const error = await response.json();
            return alert(error.message);
        }

        document.querySelector(`input[name="author"]`).value = ``;
        document.querySelector(`input[name="content"]`).value = ``;
    });

    document.getElementById(`refresh`).addEventListener(`click`, async() => {

        const response = await fetch(url);
        const messages = await response.json();

        const result = Object.values(messages).map(msg => `${msg.author}: ${msg.content}`).join(`\n`);

        document.getElementById(`messages`).textContent = result;
    })
}

attachEvents();