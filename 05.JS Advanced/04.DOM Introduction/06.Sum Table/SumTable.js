function sumTable() {

    let tableElemnts = document.querySelectorAll(`table tr`);

    let total = 0;

    for (let i = 1; i < tableElemnts.length; i++) {
        let cols = tableElemnts[i].children;
        let cost = cols[cols.length - 1].textContent;
        total += Number(cost);
        
    }

    document.getElementById(`sum`).textContent = total;

}