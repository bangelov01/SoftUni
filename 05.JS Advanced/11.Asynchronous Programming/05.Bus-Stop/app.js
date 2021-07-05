async function getInfo() {
    
    const stopIdElment = document.getElementById(`stopId`);
    let neededId = stopIdElment.value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/` + neededId;

    try {
        const busesElement = document.getElementById(`buses`);
        busesElement.innerHTML = ``;

        const response = await fetch(url);
        const busInfo = await response.json();

        document.getElementById(`stopName`).textContent = busInfo.name;

        Object.entries(busInfo.buses).map(([bus, time]) => {
            const result = document.createElement(`li`);
            result.textContent = `Bus ${bus} arrives in ${time} minutes`;
            busesElement.appendChild(result);
        });

        stopIdElment.value = ``;
    } catch (error) {
        document.getElementById(`stopName`).textContent = `Error`;
    }
}