function solve() {
    let nameElement = document.querySelector(`input[placeholder="Name"]`);
    let hallElement = document.querySelector(`input[placeholder="Hall"]`);
    let priceElement = document.querySelector(`input[placeholder="Ticket Price"]`);
    let clearButtonArchive = document.querySelector(`#archive button`);

    let onScreenButton = document.querySelector(`#container button`);

    onScreenButton.addEventListener(`click`, (e) => {
        e.preventDefault();

        let name = nameElement.value;
        let hall = hallElement.value;
        let price = parseInt(priceElement.value);

        if (name === `` || hall === `` || isNaN(price)) {

            nameElement.value = ``;
            hallElement.value = ``;
            priceElement.value = ``;
            return;
        }
        //main ul
        let root = document.querySelector(`#movies ul`);
        //parent
        let li = document.createElement("li");
        //li children
        let span = document.createElement("span");
        let strong = document.createElement("strong");
        let div = document.createElement("div");
        //div children
        let strongDiv = document.createElement("strong");
        let inputDiv = document.createElement("input");
        let buttonDiv = document.createElement("button");

        span.textContent = name;
        strong.textContent = `Hall: ${hall}`;
        strongDiv.textContent = price.toFixed(2);
        inputDiv.placeholder = "Tickets Sold";
        buttonDiv.textContent = `Archive`;

        div.appendChild(strongDiv);
        div.appendChild(inputDiv);
        div.appendChild(buttonDiv);

        li.appendChild(span);
        li.appendChild(strong);
        li.appendChild(div);

        root.appendChild(li);

        nameElement.value = ``;
        hallElement.value = ``;
        priceElement.value = ``;

        buttonDiv.addEventListener(`click`, () => {

            if (isNaN(parseInt(inputDiv.value)) || inputDiv.value === ``) {
                return;
            }

            //main ul
            let rootArchive = document.querySelector(`#archive ul`);
            //create li
            let liArchive = document.createElement("li");
            //li children
            let spanArchive = document.createElement("span");
            let strongArchive = document.createElement("strong");
            let buttonArchive = document.createElement("button");

            spanArchive.textContent = name;
            let totalPrice = Number(price) * Number(inputDiv.value)
            strongArchive.textContent = `Total amount: ${totalPrice.toFixed(2)}`;
            buttonArchive.textContent = `Delete`;

            liArchive.appendChild(spanArchive);
            liArchive.appendChild(strongArchive);
            liArchive.appendChild(buttonArchive);

            rootArchive.appendChild(liArchive);

            buttonArchive.addEventListener(`click`,() => {
                liArchive.remove();
            });

            li.remove();
        });
    });

    clearButtonArchive.addEventListener(`click`, () => {
        Array.from(document.querySelectorAll(`#archive ul li`))
        .forEach(el => el.remove());
    });
}