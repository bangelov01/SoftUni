function attachEventsListeners() {

    let daysInputElement = document.getElementById(`days`);
    let hoursInputElement = document.getElementById(`hours`);
    let minutesInputElement = document.getElementById(`minutes`);
    let secondsInputElement = document.getElementById(`seconds`);

    let daysButtonElement = document.getElementById(`daysBtn`);
    let hoursButtonElement = document.getElementById(`hoursBtn`);
    let minutesButtonElement = document.getElementById(`minutesBtn`);
    let secondsButtonElement = document.getElementById(`secondsBtn`);

    daysButtonElement.addEventListener(`click`, () =>{
        hoursInputElement.value = daysInputElement.value * 24;
        minutesInputElement.value = daysInputElement.value * 1440;
        secondsInputElement.value = daysInputElement.value * 86400;
    });

    hoursButtonElement.addEventListener(`click`, () =>{
        daysInputElement.value = hoursInputElement.value / 24;
        minutesInputElement.value = hoursInputElement.value * 60;
        secondsInputElement.value = hoursInputElement.value * 3600;
    });

    minutesButtonElement.addEventListener(`click`, () =>{
        daysInputElement.value = minutesInputElement.value / 1440;
        hoursInputElement.value = minutesInputElement.value / 60;
        secondsInputElement.value = minutesInputElement.value * 60;
    });

    secondsButtonElement.addEventListener(`click`, () =>{
        daysInputElement.value = secondsInputElement.value / 86400;
        hoursInputElement.value = secondsInputElement.value / 3600;
        minutesInputElement.value = secondsInputElement.value / 60;
    });
}