import { createElement } from "./dom.js";
import { showEdit } from "./edit.js";

let main;
let section;
let setActiveNav;

export function setupDetails(mainTarget, sectionTarget, setActiveNavCallback) {
    main = mainTarget;
    section = sectionTarget;
    setActiveNav = setActiveNavCallback;

}

export async function showDetails(id) {
    // with no id setActiveNav will remove active on all nav elements
    setActiveNav();
    section.innerHTML = ``;
    main.innerHTML = ``;
    main.appendChild(section);

    const recipe = await getRecipeById(id);
    const card = createRecipeCard(recipe);

    section.appendChild(card);
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

    const userId = sessionStorage.getItem('userId');

    if (userId == fullRecipe._ownerId) {
        result.appendChild(createElement('div', { className: 'controls' },
            createElement('button', { onClick: () => showEdit(fullRecipe._id) }, '\u270E Edit'),
            createElement('button', { onClick: () => onDelete(fullRecipe._id)}, '\u2716 Delete'),
        ));
    }

    return result;
}

async function onDelete(id) {
    const confirmed = confirm(`Are you sure you want to delete this recipe?`);
    if (confirmed) {

        const token = sessionStorage.getItem(`userToken`);
    
        await fetch(`http://localhost:3030/data/recipes/` + id, {
            method: `delete`,
            headers: {
                "X-Authorization": token
            },
        });

        section.innerHTML = ``;
        const article = createElement(`article`,{},
            createElement(`h2`,{}, 'Recipe Deleted')
        )
        section.appendChild(article);
    }
}