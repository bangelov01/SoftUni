import { html, render } from "../node_modules/lit-html/lit-html.js";
import * as request from "./data.js"

async function solve() {

    const rowTemplate = (book) => html`
    <tr>
        <td>${book.title}</td>
        <td>${book.author}</td>
        <td data-id=${book._id}>
            <button class="editBtn">Edit</button>
            <button class="deleteBtn">Delete</button>
        </td>
    </tr>
    `;

    const tableTemplate = (books) => html`
    <table>
        <thead>
            <tr>
                <th>Title</th>
                <th>Author</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody @click=${onClick}>
            ${books.map(rowTemplate)}
        </tbody>
    </table>
    `;

    const createFormTemplate = () => html`
    <form id="add-form">
        <h3>Add book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Submit">
    </form>
    `;

    const editFormTemplate = (book) => html`
    <form id="edit-form">
        <input type="hidden" name="_id" .value=${book._id}>
        <h3>Edit book</h3>
        <label>TITLE</label>
        <input type="text" name="title" .value=${book.title} placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" .value=${book.author} placeholder="Author...">
        <input type="submit" value="Save">
    </form>
    `;

    const pageTemplate = (books, bookEdit) => html`
        <button id="loadBooks" @click=${updatePage}>LOAD ALL BOOKS</button>
        ${tableTemplate(books)}
        ${bookEdit ? editFormTemplate(bookEdit) : createFormTemplate()}
    `;

    render(pageTemplate([]), document.body); //initial render

    const onSubmit = {
        "add-form": onAddSubmit,
        "edit-form": onEditSubmit,
    }

    document.body.addEventListener('submit', async (e) => {
        e.preventDefault();

        const formData = new FormData(e.target);
        onSubmit[e.target.id](formData);
        e.target.reset();
    });

    async function onClick(e) {
        if (e.target.classList.contains('editBtn')) {
            const id = e.target.parentElement.dataset.id;
            const books = await request.getAllBooks();
            const neededBook = books.find(x => x._id == id)
            render(pageTemplate(books, neededBook), document.body)

        } else if (e.target.classList.contains('deleteBtn')) {
            const id = e.target.parentElement.dataset.id;
            await request.deleteBook(id);
            updatePage();
        }
    }
    

    async function updatePage() {
        const books = await request.getAllBooks();
        render(pageTemplate(books), document.body)
    }

    async function onAddSubmit(formData) {
        try {

            const title = formData.get('title');
            const author = formData.get('author');
            if (title == '' || author == '') { throw new Error('Fields should not be empty!') }
            await request.createBook({ title, author });
            await updatePage();

        } catch (error) {
            alert(error.message)
        }
    }

    async function onEditSubmit(formData) {
        try {

            const id = formData.get('_id');
            const title = formData.get('title');
            const author = formData.get('author');
            if (title == '' || author == '') { throw new Error('Fields should not be empty!') }
            await request.updateBook(id, { title, author });
            await updatePage();

        } catch (error) {
            alert(error.message)
        }
    }
}

solve();