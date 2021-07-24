async function request(url, options) {
    const response = await fetch(url, options);
    const data = await response.json();

    return data;
}

async function getAllBooks() {
    return Object
    .entries(await request('http://localhost:3030/jsonstore/collections/books'))
    .map(([k,v]) => Object.assign(v, {_id: k}));
}

async function getBookById(id) {
    return await request('http://localhost:3030/jsonstore/collections/books/' + id)
}

async function createBook(book) {
    return await request('http://localhost:3030/jsonstore/collections/books', {
        method: 'post',
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(book)
    })
}

async function updateBook(id, book) {
    return await request('http://localhost:3030/jsonstore/collections/books/' + id, {
        method: 'put',
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(book)
    })
}

async function deleteBook(id) {
    return await request('http://localhost:3030/jsonstore/collections/books/' + id, {
        method: 'delete'
    })
}

export {
    getAllBooks,
    getBookById,
    createBook,
    updateBook,
    deleteBook
}