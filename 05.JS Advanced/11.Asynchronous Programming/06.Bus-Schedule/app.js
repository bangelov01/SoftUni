function solve() {

    let nextStopId = `depot`;
    let currentStopName = ``;
    const baseUrl = `http://localhost:3030/jsonstore/bus/schedule/`;
    const stopInfoElement = document.querySelector(`.info`);

    async function depart() {   

        const stop = await getStop(nextStopId, baseUrl);

        nextStopId = stop.next;
        currentStopName = stop.name;
        stopInfoElement.textContent = `Next stop ${stop.name}`;
        document.getElementById(`depart`).disabled = true;
        document.getElementById(`arrive`).disabled = false;

        async function getStop(nextStopId, url) {

            const response = await fetch(url + `${nextStopId}`);
            const stop = await response.json();

            return stop;
        }
    }

    function arrive() {
        stopInfoElement.textContent = `Arriving at ${currentStopName}`;
        document.getElementById(`depart`).disabled = false;
        document.getElementById(`arrive`).disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();