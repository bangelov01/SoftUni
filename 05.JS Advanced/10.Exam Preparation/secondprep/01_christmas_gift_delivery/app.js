function solution() {
    let getAddButton = document.querySelector(`.container section:first-child div:last-child button:last-child`);

    let itemsRepo = [];

    getAddButton.addEventListener(`click`, (e) => {
        document.querySelector(`.container section:nth-child(2) ul:last-child`).innerHTML = ``;
        let inputElement = e.target.previousElementSibling;
        configureListItemToRepo(inputElement.value);
        createItemLiElements(itemsRepo);

        inputElement.value = ``;

        function configureListItemToRepo(itemName) {
            itemsRepo.push(itemName);
            itemsRepo.sort((a, b) => a.localeCompare(b));
        }

        function createItemLiElements(itemRepo) {

            for (const item of itemRepo) {
                let li = document.createElement(`li`);
                li.classList.add(`gift`);
                li.textContent = `${item}`;
                let buttonSend = document.createElement(`button`);
                buttonSend.id = `sendButton`;
                buttonSend.textContent = `Send`;
                buttonSend.addEventListener(`click`, (e) => {
                    let buttonType = e.target.textContent;
                    let neededLI = e.currentTarget.parentElement;
                    manipulateSentLiElement(neededLI, buttonType);
                })
                let buttonDiscard = document.createElement(`button`);
                buttonDiscard.id = `discardButton`;
                buttonDiscard.textContent = `Discard`;
                buttonDiscard.addEventListener(`click`, (e) => {
                    let buttonType = e.target.textContent;
                    let neededLI = e.currentTarget.parentElement;
                    manipulateSentLiElement(neededLI, buttonType);
                })
                li.appendChild(buttonSend);
                li.appendChild(buttonDiscard);

                appendItemLiElementToDom(li);
            }
        }

        function appendItemLiElementToDom(element) {
            document
                .querySelector(`.container section:nth-child(2) ul:last-child`)
                .appendChild(element);
        }

        function manipulateSentLiElement(element, buttonType) {

            let saveItemName = element.textContent.replace(`SendDiscard`, ``);
            element.remove();
            element.innerHTML = ``;
            element.textContent = saveItemName;
            removeItemFromRepo(saveItemName, itemsRepo);
            appendSentItemElementToDom(element, buttonType);
        }

        function removeItemFromRepo(itemName, repo) {
            itemsRepo = repo.filter(el => el != itemName);
            itemsRepo.sort((a,b) => a.localeCompare(b));
        }

        function appendSentItemElementToDom(element, buttonType){

            let childNumber;

            if (buttonType === `Send`) {
                childNumber = 3;
            }
            else if (buttonType === `Discard`) {
                childNumber = 4;
            }
            document
            .querySelector(`.container section:nth-child(${childNumber}) ul:last-child`)
            .appendChild(element);
        }
    })
}