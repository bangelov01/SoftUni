window.addEventListener(`load`, () => {

    const url = `http://localhost:3030/jsonstore/cookbook/recipes`;

    fetch(url)
        .then((response) => response.json())
        .then((data) => {
            const mainElement = document.querySelector(`body main`);
            mainElement.innerHTML = ``;

            for (const recipe in data) {
                const result = e(`article`, {className: `preview`},
                    e(`div`, {className: `title`}, e(`h2`, {}, data[recipe].name)),
                    e(`div`, {className: `small`}, e(`img`, {src: data[recipe].img}))
                );

                mainElement.appendChild(result);
            }
        })
        .catch((error) => {
            alert(error.message);
        });
})

function e(type, attributes, ...content) {
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

/*<article class="preview">
            <div class="title">
                <h2>Title</h2>
            </div>
            <div class="small">
                <img src="assets/lasagna.jpg">
            </div>
        </article>*/