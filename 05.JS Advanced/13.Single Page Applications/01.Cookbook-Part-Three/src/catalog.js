import {createElement} from "./dom.js";
import {showDetails} from "./details.js";


let main;
let section;
let setActiveNav;

    //setup section
export function setupCatalog(mainTarget, sectionTarget, setActiveNavCallback) {
    // - store section reference
    // - store main element reference
    // - initialize event listeners(if required)

    main = mainTarget;
    section = sectionTarget;
    setActiveNav = setActiveNavCallback;

}

    //display function
export async function showCatalog() {

    // - fetch data(if required)
    // - clear main elemnt HTML
    // - attach section
    setActiveNav('catalogLink');

    section.innerHTML = ``;
    main.innerHTML = ``;
    main.appendChild(section);

    const recipes = await getRecipes();
    const cards = recipes.map(createRecipePreview);

    const fragment = document.createDocumentFragment();
    cards.forEach(card => fragment.appendChild(card));
    section.appendChild(fragment);

}

async function getRecipes() {

    try {
        const response = await fetch(`http://localhost:3030/data/recipes?select=_id%2Cname%2Cimg`);
        const recipes = await response.json();

        return Object.values(recipes);

    } catch (error) {
        alert(error.message);
    }
}

async function getRecipeById(id) {

    try {
        const idUrl = `http://localhost:3030/data/recipes/${id}`;

        const response = await fetch(idUrl);
        const recipe = await response.json();

        return recipe;

    } catch (error) {
        alert(error.message);
    }
}

function createRecipePreview(recipe) {

    const result = createElement(`article`, { className: `preview`, onClick: () => showDetails(recipe._id) },
        createElement(`div`, { className: `title` }, createElement(`h2`, {}, recipe.name)),
        createElement(`div`, { className: `small` }, createElement(`img`, { src: recipe.img }))
    );

    return result;
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
        createElement(`div`, { className: `description` },
            createElement(`h3`, {}, `Preparation:`),
            fullRecipe.steps.map(s => createElement(`p`, {}, s))
        ),
    )

    return result;
}