function deleteByEmail() {
    let inputElement = document.querySelector(`[name = "email"]`);

    let tableBodyElemnt = document.querySelector(`tbody`);
    let length = tableBodyElemnt.rows.length;

    for (let i = 0; i < length; i++) {
        
        let neededText = tableBodyElemnt.rows[i].cells[1].textContent;

        if (neededText === inputElement.value) {
            tableBodyElemnt.rows[i].remove();
            document.getElementById(`result`).textContent = `Deleted.`;
            return;
        }      
    }

    document.getElementById(`result`).textContent = "Not found.";
}