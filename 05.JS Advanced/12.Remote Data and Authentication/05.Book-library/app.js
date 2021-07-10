async function solve() {

    let tBodyElement = document.querySelector(`table tbody`);
    const baseUrl = `http://localhost:3030/jsonstore/collections/books/`;

    document.getElementById(`loadBooks`).addEventListener(`click`, async (e) => {

        await updateTable(baseUrl, tBodyElement);
    });

    document.querySelector(`table`).addEventListener(`click`, async (e) => {

        if (e.target.id == `editBtn`) {

            document.getElementById(`main-form`).style.display = `none`;
            let editForm = document.getElementById(`edit-form`);
            editForm.style.display = `block`;
            editForm.setAttribute(`data-id`, e.target.parentElement.dataset.id);

            editForm.children[2].value = e.target.parentElement.dataset.title;
            editForm.children[4].value = e.target.parentElement.dataset.author;
        }
        else if (e.target.id == `deleteBtn`) {

            await fetch(baseUrl + e.target.parentElement.dataset.id, {
                method: `delete`
            });

            updateTable(baseUrl, tBodyElement);

            const mainForm = document.getElementById(`main-form`);
            mainForm.style.display = `block`;
            mainForm.reset();

            const editForm = document.getElementById(`edit-form`);
            editForm.style.display = `none`;
            editForm.reset();
        }
    });

    document.getElementById(`edit-form`).addEventListener(`submit`, async (e) => {
        e.preventDefault();

        const formData = new FormData(e.target);
        const dataTitle = formData.get(`title`);
        const dataAuthor = formData.get(`author`);

        if (dataTitle == `` || dataAuthor == ``) {
            throw alert(`Fields must not be empty!`);
        }

        await fetch(baseUrl + e.target.dataset.id, {
            method: `put`,
            headers: { "Content-Type": `application/json` },
            body: JSON.stringify({ author: dataAuthor, title: dataTitle })
        });

        e.target.style.display = `none`;
        document.getElementById(`main-form`).style.display = `block`;
        e.target.reset();

        updateTable(baseUrl, tBodyElement);
    });

    document.getElementById(`main-form`).addEventListener(`submit`, async (e) => {

        e.preventDefault();

        const formData = new FormData(e.target);
        const dataTitle = formData.get(`title`);
        const dataAuthor = formData.get(`author`);

        if (dataTitle == `` || dataAuthor == ``) {
            throw alert(`Fields must not be empty!`);
        }

        await fetch(baseUrl, {
            method: `post`,
            headers: { "Content-Type": `application/json` },
            body: JSON.stringify({ author: dataAuthor, title: dataTitle })
        });
        
        e.target.reset();

        updateTable(baseUrl, tBodyElement);
    })

    async function updateTable(url, tBody) {

        const books = await getBooks(url);

        tBody.innerHTML = ``;

        createRows(books, tBody);

        async function getBooks(url) {

            const response = await fetch(url);
            const books = await response.json();

            return books;
        }

        function createRows(books, tBody) {

            for (let i = 0; i < Object.keys(books).length; i++) {

                let bookValue = Object.values(books)[i];
                delete bookValue._id;

                let bookKey = Object.keys(books)[i];

                let newRow = tBody.insertRow();

                Object.keys(bookValue).forEach((k) => {
                    newRow.insertCell().textContent = bookValue[k];
                });

                let actionCell = newRow.insertCell();

                actionCell.setAttribute(`data-id`, bookKey);
                actionCell.setAttribute(`data-title`, books[bookKey].title);
                actionCell.setAttribute(`data-author`, books[bookKey].author);

                appendButtons(actionCell);

                function appendButtons(actionCell) {

                    const editButton = createEditButton();
                    const deleteButton = createDeleteButton();

                    actionCell.appendChild(editButton);
                    actionCell.appendChild(deleteButton);


                    function createEditButton() {

                        let editBtn = document.createElement(`button`);
                        editBtn.setAttribute(`id`, `editBtn`);
                        editBtn.textContent = `Edit`;

                        return editBtn;
                    }

                    function createDeleteButton() {

                        let deleteBtn = document.createElement(`button`);
                        deleteBtn.setAttribute(`id`, `deleteBtn`);
                        deleteBtn.textContent = `Delete`;

                        return deleteBtn;
                    }
                }
            }
        }
    }
}

solve();