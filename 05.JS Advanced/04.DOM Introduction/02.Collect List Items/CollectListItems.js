function extractText() {
    let elements = document.querySelectorAll("#items li");
    let destinationElement = document.querySelector("#result");

    for (const element of elements) {
        destinationElement.value += element.textContent + `\n`;
    }

    destinationElement.textContent.trim();
}