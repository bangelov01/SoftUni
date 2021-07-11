const userToken = sessionStorage.getItem(`userToken`);

let currentOwnerId = ``;

if (userToken != null) {

    document.getElementById(`user`).style.display = `inline-block`;
    document.querySelector(`#addForm .add`).disabled = false;
    document.querySelector(`#catches h3`).textContent = `Click Load to preview catches,\r\nor Add to add catch!`;

    document.getElementById(`logoutBtn`).addEventListener(`click`, async () => {

        const response = await fetch(`http://localhost:3030/users/logout`, {
            method: `get`,
            headers: { "X-Authorization": userToken }
        });

        if (!response.ok) {
            const error = await response.json();
            return alert(error.message);
        }

        sessionStorage.removeItem(`userToken`);
        currentOwnerId = ``;
        window.location.pathname = `index.html`;
    });

    document.querySelector(`#addForm .add`).addEventListener(`click`, async() => {

        const addCatchEl = Array.from(document.getElementById(`addForm`).children);

        let postObj = {};

        for (let i = 2; i < addCatchEl.length; i+=2) {

            const prop = addCatchEl[i].className;

            if (addCatchEl[i].value == ``) {
                throw alert(`All fields must be filled!`);
            }
            postObj[prop] = addCatchEl[i].value;
        }

        const response = await fetch(`http://localhost:3030/data/catches`, {
            method: `post`,
            headers: {"X-Authorization": userToken},
            body: JSON.stringify(postObj)
        })

        if (!response.ok) {
            const error = await response.json();
            return alert(error.message);
        }

        for (let i = 2; i < addCatchEl.length; i+=2) {
            addCatchEl[i].value = ``;
        }

        const result = await response.json();
        currentOwnerId = result._ownerId;

        await updateCatches(currentOwnerId);
    });
}
else {
    document.getElementById(`guest`).style.display = `inline-block`;
};

document.querySelector(`.load`).addEventListener(`click`, async () => {

    await updateCatches(currentOwnerId);
});

document.getElementById(`catches`).addEventListener(`click`, async (e) => {

    if (e.target.className == `update` && e.target.disabled == false) {
        
        const inputs = Array.from(e.target.parentElement.children);
        let postObj = {};

        for (let i = 1; i < inputs.length - 1; i+=3) {

            const prop = inputs[i].className;

            if (inputs[i].value == ``) {
                throw alert(`All fields must be filled!`);
            }

            postObj[prop] = inputs[i].value;
        }
        console.log(e.target.parentElement.id);
        const response = await fetch(`http://localhost:3030/data/catches/${e.target.parentElement.id}`, {
            method: `put`,
            headers: {"X-Authorization": userToken},
            body: JSON.stringify(postObj)
        });

        if (!response.ok) {
            const error = await response.json();
            return alert(error.message);
        }

        await updateCatches(currentOwnerId);
    }
    else if (e.target.className == `delete` && e.target.disabled == false) {
        await fetch(`http://localhost:3030/data/catches/${e.target.parentElement.id}`,{
            method: `delete`,
            headers: {"X-Authorization": userToken}
        });

        e.target.parentElement.remove();
    }
})

async function updateCatches(currentOwnerId) {

    let catchesElement = document.getElementById(`catches`);
    catchesElement.innerHTML = ``;

    const response = await fetch(`http://localhost:3030/data/catches`);
    const catches = await response.json();

    Object.values(catches).forEach(c => {

        const el = createCatchDiv(c);
        catchesElement.appendChild(el);

    });

    enableButtons(currentOwnerId);

    function createCatchDiv(c) {

        const result = createElement(`div`, { className: "catch", ownerid: `${c._ownerId}`, id: `${c._id}` },
            createElement(`label`, {}, `Angler`),
            createElement(`input`, { type: `text`, className: `angler`, value: c.angler }),
            createElement(`hr`, {}),
            createElement(`label`, {}, `Weight`),
            createElement(`input`, { type: `number`, className: `weight`, value: c.weight }),
            createElement(`hr`, {}),
            createElement(`label`, {}, `Species`),
            createElement(`input`, { type: `text`, className: `species`, value: c.species }),
            createElement(`hr`, {}),
            createElement(`label`, {}, `Location`),
            createElement(`input`, { type: `text`, className: `location`, value: c.location }),
            createElement(`hr`, {}),
            createElement(`label`, {}, `Bait`),
            createElement(`input`, { type: `text`, className: `Bait`, value: c.bait }),
            createElement(`hr`, {}),
            createElement(`label`, {}, `Capture Time`),
            createElement(`input`, { type: `number`, className: `captureTime`, value: c.weight }),
            createElement(`button`, { className: `update`, disabled: `disabled` }, `Update`),
            createElement(`button`, { className: `delete`, disabled: `disabled` }, `Delete`),

        )

        return result;
    }

    function createElement(type, attributes, ...content) {
        const result = document.createElement(type);

        for (let [attr, value] of Object.entries(attributes || {})) {
            if (attr.substring(0, 2) == 'on') {
                result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
            } else {
                result[attr] = value;
            }
        }

        content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }

    function enableButtons(ownerId) {

        const catchElements = document.getElementById(`catches`).children;
        Array.from(catchElements).forEach(el => {
            if (el.ownerid == ownerId) {
                el.querySelector(`.update`).disabled = false;
                el.querySelector(`.delete`).disabled = false;
            }
        });
    }
}

