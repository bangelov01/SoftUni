import { html, render } from "../node_modules/lit-html/lit-html.js";
import { towns } from "./towns.js";

function search() {
   const divTowns = document.getElementById('towns');
   const result = document.getElementById('result');

   const ulTemplate = (towns, found) => html`
   <ul>
      ${towns.map(t => html`<li class=${found.includes(t.toLowerCase()) ? "active" : ""}>${t}</li>`)}
   </ul>
   `;

   render(ulTemplate(towns, []), divTowns);

   document.querySelector('button').addEventListener('click', () => {

      let searchValue = document.querySelector('#searchText').value.toLowerCase();
      const found = towns.map(t => t.toLowerCase()).filter(t => t.includes(searchValue));

      if (!found || searchValue =='') {
         result.textContent = 'No matches found!'
      } else {
         render(ulTemplate(towns, found), divTowns);
         result.textContent = `${found.length} matchs found!`;
      }
      document.querySelector('#searchText').value = '';
   });
}

search();
