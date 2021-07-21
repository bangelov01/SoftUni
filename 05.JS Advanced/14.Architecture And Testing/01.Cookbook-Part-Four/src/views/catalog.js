import { createElement } from "../dom.js";
import { getRecipes } from "../api/data.js";

export function setupCatalog(section, navigation) {

    return showCatalog;

    async function showCatalog() {
        section.innerHTML = ``;

        const recipes = await getRecipes();
        const cards = recipes.map(r => createRecipePreview(r, navigation.goTo));

        const fragment = document.createDocumentFragment();
        cards.forEach(card => fragment.appendChild(card));
        section.appendChild(fragment);

        return section;

    }


    function createRecipePreview(recipe, goTo) {

        const result = createElement(`article`, { className: `preview`, onClick: () => goTo('details', recipe._id) },
            createElement(`div`, { className: `title` }, createElement(`h2`, {}, recipe.name)),
            createElement(`div`, { className: `small` }, createElement(`img`, { src: recipe.img }))
        );

        return result;
    }

}