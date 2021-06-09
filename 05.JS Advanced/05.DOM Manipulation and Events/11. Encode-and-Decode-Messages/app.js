function encodeAndDecodeMessages() {
    let senderTextAreaElement = document.querySelectorAll(`#main div textarea`);
    let sentMessageElement = senderTextAreaElement[0];
    let recievedMessageElement = senderTextAreaElement[1];
    let buttonElements = document.querySelectorAll(`#main div button`);
    let sendButton = buttonElements[0];
    let decodeButton = buttonElements[1];
    let initialMessage = ``;

    sendButton.addEventListener(`click`, () => {
        initialMessage = sentMessageElement.value;
        let newMessage = ``;

        for (const char of initialMessage) {
            newMessage += String.fromCharCode(char.charCodeAt(0) + 1);
        }

        recievedMessageElement.value = newMessage;
        sentMessageElement.value = ``;
    });

    decodeButton.addEventListener(`click`, () =>{
        recievedMessageElement.value = initialMessage;
    })
}