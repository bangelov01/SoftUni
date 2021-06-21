function solve(ticketDescrArr, sortingCriteria) {

    class Ticket {

        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let result = [];

    for (let i = 0; i < ticketDescrArr.length; i++) {
        
        let [destination, price, status] = ticketDescrArr[i].split(`|`);

        let ticket = new Ticket(destination, price, status);

        result.push(ticket);       
    }

    result.sort((a,b) => {
        if (sortingCriteria != `price`) {
            return a[sortingCriteria].localeCompare(b[sortingCriteria]);
        }
        else{
            return a[sortingCriteria] + b[sortingCriteria];
        }
    });
    return result;
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'price')