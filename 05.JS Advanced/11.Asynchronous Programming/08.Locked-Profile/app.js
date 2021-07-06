async function lockedProfile() {

    const url = `http://localhost:3030/jsonstore/advanced/profiles`;
    const main = document.getElementById(`main`);
    main.innerHTML = ``;

    const response = await fetch(url);
    const personInfo = await response.json();

    createProfileCards(personInfo).forEach(el => main.appendChild(el));
    

    function createProfileCards(personInfo) {

        const result = Object.values(personInfo).map((card,i) => createElement(`div`, { className: `profile` },
            createElement(`img`, { src: "./iconProfile2.png", className: `userIcon` }),
            createElement(`label`, {}, `Lock`),
            createElement(`input`, { type: `radio`, name: `user${i}Locked`, value: `lock`, checked: true}),
            createElement(`label`, {}, `Unlock`),
            createElement(`input`, { type: `radio`, name: `user${i}Locked`, value: `unlock`, checked: false}),
            createElement(`br`, {}, []),
            createElement(`hr`, {}, []),
            createElement(`label`, {}, `Username`),
            createElement(`input`, { type: `text`, name: `user${i}Username`, value: `${card.username}`, disabled: true, readonly: true }),
            createElement(`div`, { id: `User${i}HiddenFields`, style: `display:none`},
                createElement(`hr`, {}, []),
                createElement(`label`, {}, `Email:`),
                createElement(`input`, { type: `email`, name: `user${i}Email`, value: `${card.email}`, disabled: true, readonly: true }),
                createElement(`label`, {}, `Age:`),
                createElement(`input`, { type: `email`, name: `user${i}Age`, value: `${card.age}`, disabled: true, readonly: true })),
            createElement(`button`, {onClick: toggleShowMore},`Show more`)
            )
        )
        return result;

        function toggleShowMore(e) {

            const lockedInput = e.target.parentElement.children[2].checked;
            const hiddenElement =  e.target.parentElement.children[9];

            if (lockedInput) {
                return;
            }

           hiddenElement.style.display = hiddenElement.style.display === `block` ? `none` : `block`;
           e.target.textContent = e.target.textContent === `Show more` ? `Hide it` : `Show more`;
            
        }
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