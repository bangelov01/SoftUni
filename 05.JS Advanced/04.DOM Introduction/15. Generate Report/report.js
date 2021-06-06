function generateReport() {
    let tableHeadElements = document.querySelectorAll(`tr th`);
    let headElementsArray = Array.from(tableHeadElements);

    let columnIndexes = [];

    for (let i = 0; i < headElementsArray.length; i++) {
        
        if (headElementsArray[i].children[0].checked) {
            columnIndexes.push(i);
        }
    }

    let table = document.querySelector(`tbody`);
    let tbodyLength = table.rows.length;

    let result = [];

    for (let j = 0; j < tbodyLength; j++) {
        let obj = {};
        
        for (const colIndex of columnIndexes) {
            let needed = table.rows[j].cells[colIndex].textContent;
            obj[headElementsArray[colIndex].textContent.toLowerCase().trim()] = needed;
        }

        result.push(obj);
    }
    
    let jsonParse = JSON.stringify(result);

    document.getElementById(`output`).textContent = jsonParse;
}