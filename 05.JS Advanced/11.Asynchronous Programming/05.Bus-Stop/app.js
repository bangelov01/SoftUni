async function getInfo() {
    
    const mainElement = document.getElementById(`result`);
    const baseUrl = `http://localhost:3030/jsonstore/bus/businfo/`;
    const stopIdElment = document.getElementById(`stopId`);
    let neededId = stopIdElment.value;

    const stop = await getBusStop(baseUrl, neededId);

    if (stop instanceof Error) {
        mainElement.children[1].innerHTML = ``;
        document.getElementById(`stopName`).textContent = `Error`;
    }
    else {
        mainElement.innerHTML = ``;
        mainElement.replaceWith(createResultElement(stop));
    }

    async function getBusStop(url,id) {

        try {
            const response = await fetch(url + `${id}`);
            const stop = await response.json();
    
            return stop;
        } catch (error) {
            return error;
        }
    }

    function createResultElement(stop) {

        const result = createElement(`div`, {id: `result`},
            createElement(`div`, {id: `stopName`}, stop.name),
            createElement(`ul`, {id: `buses`}, 
            Object.entries(stop.buses).map(b => createElement(`li`, {}, `Bus ${b[0]} arrives in ${b[1]} minutes`))
            ),
        )

        return result;
    }

    function createElement(type, attributes, ...content) {
        const result = document.createElement(type);
    
        for (let [attr, value] of Object.entries(attributes || {})) {
            if (attr.substring(0, 2) == 'on') {
                result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
            } else {
                result[attr] = value;
            }
        }
    
        content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);
    
        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });
    
        return result;
    }
}