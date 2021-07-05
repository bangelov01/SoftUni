window.addEventListener(`load`, async() => {

    const url = `http://localhost:3030/jsonstore/cookbook/recipes`;
    const mainElment = document.querySelector(`main`);

    const recipes = await getRecipes(url);
    const cards = recipes.map(createRecipePreview);

    mainElment.innerHTML = ``;
    cards.forEach(card => mainElment.appendChild(card));

})

async function getRecipes(url) {

    try {
        const response = await fetch(url);
        const recipes = await response.json();

        return Object.values(recipes);

    } catch (error) {
        alert(error.message);
    }
}

async function getRecipeById(id) {

    try {
        const idUrl = `http://localhost:3030/jsonstore/cookbook/details/${id}`;

        const response = await fetch(idUrl);
        const recipe = await response.json();

        return recipe;

    } catch (error) {
        alert(error.message);
    }
}

function createRecipePreview(recipe) {

    const result = createElement(`article`, { className: `preview`, onClick: toggleCard },
        createElement(`div`, { className: `title` }, createElement(`h2`, {}, recipe.name)),
        createElement(`div`, { className: `small` }, createElement(`img`, { src: recipe.img }))
    );

    return result;

    async function toggleCard() {

        const fullRecipe = await getRecipeById(recipe._id);

        result.replaceWith(createRecipeCard(fullRecipe));
    }
}

function createRecipeCard(fullRecipe) {

    const result = createElement(`article`, {},
        createElement(`h2`, {}, fullRecipe.name,),
        createElement(`div`, { className: `band` },
            createElement(`div`, { className: `thumb` }, createElement(`img`, { src: fullRecipe.img })),
            createElement(`div`, { className: `ingredients` },
                createElement(`h3`, {}, `Ingredients:`),
                createElement(`ul`, {}, fullRecipe.ingredients.map(i => createElement(`li`, {}, i))),
            )
        ),
        createElement(`div`, {className: `description`},
            createElement(`h3`, {}, `Preparation:`),
            fullRecipe.steps.map(s => createElement(`p`, {}, s))
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