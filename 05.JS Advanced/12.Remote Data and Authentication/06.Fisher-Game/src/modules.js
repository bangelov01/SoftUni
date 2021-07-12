export async function updateCatches(currentOwnerId) {

    let catchesElement = document.getElementById(`catches`);
    catchesElement.innerHTML = ``;

    const response = await fetch(`http://localhost:3030/data/catches`);
    const catches = await response.json();

    Object.values(catches).forEach(c => {

        const el = createCatchDiv(c);
        catchesElement.appendChild(el);

    });

    enableButtons(currentOwnerId);

    function createCatchDiv(c) {

        const result = createElement(`div`, { className: "catch", ownerid: `${c._ownerId}`, id: `${c._id}` },
            createElement(`label`, {}, `Angler`),
            createElement(`input`, { type: `text`, className: `angler`, value: c.angler }),
            createElement(`hr`, {}),
            createElement(`label`, {}, `Weight`),
            createElement(`input`, { type: `number`, className: `weight`, value: c.weight }),
            createElement(`hr`, {}),
            createElement(`label`, {}, `Species`),
            createElement(`input`, { type: `text`, className: `species`, value: c.species }),
            createElement(`hr`, {}),
            createElement(`label`, {}, `Location`),
            createElement(`input`, { type: `text`, className: `location`, value: c.location }),
            createElement(`hr`, {}),
            createElement(`label`, {}, `Bait`),
            createElement(`input`, { type: `text`, className: `Bait`, value: c.bait }),
            createElement(`hr`, {}),
            createElement(`label`, {}, `Capture Time`),
            createElement(`input`, { type: `number`, className: `captureTime`, value: c.weight }),
            createElement(`button`, { className: `update`, disabled: `disabled` }, `Update`),
            createElement(`button`, { className: `delete`, disabled: `disabled` }, `Delete`),

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

    function enableButtons(ownerId) {

        const catchElements = document.getElementById(`catches`).children;
        Array.from(catchElements).forEach(el => {
            if (el.ownerid == ownerId) {
                el.querySelector(`.update`).disabled = false;
                el.querySelector(`.delete`).disabled = false;
            }
        });
    }
}