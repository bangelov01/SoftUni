import { createElement } from "../dom.js";
import {getRecipeById, onDelete} from "../api/data.js"

export function setupDetails(section, navigation) {

    return showDetails;

    async function showDetails(id) {
        section.innerHTML = ``;
   
        const recipe = await getRecipeById(id);
        const card = createRecipeCard(recipe, navigation.goTo, deleteRecipe);
    
        section.appendChild(card);

        return section;
    }

    async function deleteRecipe(id) {
    
        const confirmed = confirm(`Are you sure you want to delete this recipe?`);
        if (confirmed) {
    
            await onDelete(id);
    
            section.innerHTML = ``;
            const article = createElement(`article`,{},
                createElement(`h2`,{}, 'Recipe Deleted')
            )
            section.appendChild(article);
        }
    }

}

function createRecipeCard(fullRecipe, goTo, deleteRecipe) {

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
            createElement('button', { onClick: () => goTo('edit', fullRecipe._id) }, '\u270E Edit'),
            createElement('button', { onClick: () => deleteRecipe(fullRecipe._id)}, '\u2716 Delete'),
        ));
    }

    return result;
}