import { html, render } from "../node_modules/lit-html/lit-html.js";

async function addItem() {
    
    const menuTemplate = (items) => html`
     <select id="menu">
         ${items.map(optionTemplate)}
     </select>
    `;

    const optionTemplate = (item) => html`
    <option .value=${item._id}>${item.text}</option>
    `;

    await updateList();

    document.querySelector('form').addEventListener('submit', async(e) => {
        e.preventDefault();

        try {

            const formdata = new FormData(e.target);
            const text = formdata.get("itemText")
            if (text == '') {
                throw new Error('Field cannot be empty!')
            }
            const body = JSON.stringify({text: text});
            await post(body);

        } catch (error) {
            alert(error.message);
        }

        e.target.reset();
        await updateList();
    });

    async function get() {

        const response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
        const getData = await response.json();

        if (!response.ok) {
            const error = await response.json();
            return new Error(error.message);
        }

        return Object.values(getData);
    }

    async function post(body) {

        const response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
            method: 'post',
            headers: {"Content-Type": "application/json"},
            body: body
        })

        if (!response.ok) {
            const error = await response.json();
            return new Error(error.message);
        }
    }

    async function updateList() {
        try {
            const items = await get();
            render(menuTemplate(items), document.querySelector('body div'))
        } catch (error) {
            alert(error.message)
        }
    }
}

addItem();