import {showDetails} from "./details.js"

let main;
let section;
let setActiveNav;

export function setupEdit(mainTarget, sectionTarget, setActiveNavCallback) {
    main = mainTarget;
    section = sectionTarget;
    setActiveNav = setActiveNavCallback;

    section.querySelector(`form`).addEventListener(`submit`, async(e) => {
        e.preventDefault();
    
        const formData = new FormData(e.target);
    
        const id = e.target.dataset.id;
        const name = formData.get(`name`);
        const img = formData.get(`img`);
        const ingredients = formData.get(`ingredients`)
            .split(`\n`)
            .map(line => line.trim())
            .filter(line => line != ``);
        const steps = formData.get(`steps`)
            .split(`\n`)
            .map(line => line.trim())
            .filter(line => line != ``);
    
        const token = sessionStorage.getItem(`userToken`);
    
        const response = await fetch(`http://localhost:3030/data/recipes/` + id, {
            method: `put`,
            headers: {
                "Content-Type": `application/json`,
                "X-Authorization": token
            },
            body: JSON.stringify({ name, img, ingredients, steps })
        });
    
    
        if (!response.ok) {
            const error = await response.json();
            return alert(error.message);
        }
    
        showDetails(id);
    });
}

export async function showEdit(id) {
    setActiveNav();
    main.innerHTML = ``;
    main.appendChild(section);

    const recipe = await getRecipeById(id);

    section.querySelector('form').setAttribute('data-id', id);
    section.querySelector(`[name="name"]`).value = recipe.name;
    section.querySelector(`[name="img"]`).value = recipe.img;
    section.querySelector(`[name="ingredients"]`).value = recipe.ingredients.join('\n');
    section.querySelector(`[name="steps"]`).value = recipe.steps.join('\n');
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