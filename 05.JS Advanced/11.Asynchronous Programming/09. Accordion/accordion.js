async function solution() {
    
    const baseUrl = `http://localhost:3030/jsonstore/advanced/articles/`;

    const listResponse = await fetch(baseUrl + `list`);
    const list = await listResponse.json();

    let main = document.getElementById(`main`);

    createArticles(list).forEach(article => main.appendChild(article));

    function createArticles(list) {

        const result = Object.values(list).map(article => 
            createElement(`div`, {className: `accordion`},
                createElement(`div`, {className: `head`},
                    createElement(`span`,{},`${article.title}`),
                    createElement(`button`, {className: `button`, id: `${article._id}`, onClick: getInfo}, `More`)
                    ),
                createElement(`div`,{className: `extra`, style: `display:none`},
                    createElement(`p`,{},)
                )
            )
        )

        return result;

        async function getInfo(e) {

            if (e.target.textContent == `More`) {      

            const infoResponse = await fetch(baseUrl + `details/${e.target.id}`);
            const info = await infoResponse.json();

            e.target.parentElement.nextSibling.style.display = `block`;

            e.target.parentElement.nextSibling.children[0].textContent = info.content;

            e.target.textContent = `Less`;
            }
            else {
                
                e.target.parentElement.nextSibling.style.display = `none`;
                e.target.parentElement.nextSibling.children[0].textContent = ``;
                e.target.textContent = `More`;
            }
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

solution();