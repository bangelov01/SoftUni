import { html, render } from "../node_modules/lit-html/lit-html.js";

async function solve() {

   const tableTemplate = (infoItems, toFind) => html`
   <thead>
            <tr>
                <th>Student name</th>
                <th>Student email</th>
                <th>Student course</th>
            </tr>
        </thead>

      <tbody>
         ${infoItems.map(x => trTemplate(x, toFind))}
      </tbody>

        <tfoot>
            <tr>
                <td colspan="3">
                    <input type="text" id="searchField" />
                    <button type="button" id="searchBtn" @click=${e => onClick(e, infoItems)}>Search</button>
                </td>
            </tr>
        </tfoot>
   `;
   
   const trTemplate = (item, toFind) => html`
      <tr class=${doesMatch(item, toFind) ? "select" : ""}>
         ${Object.values(item).map(v => html`<td>${v}</td>`)}
      </tr>
   `;

   const data = await getData();

   const infoItems = data.map(x => {
      delete x._id;
      const lastName = x.lastName;
      delete x.lastName;
      x.firstName += ` ${lastName}`;
      return x;
   })

   render(tableTemplate(infoItems), document.querySelector('.container'));

   function onClick(e, infoItems) {

      render(tableTemplate(infoItems), document.querySelector('.container'));

      let searchValue = e.target.previousElementSibling.value.toLowerCase();

      if (searchValue != '') {
         render(tableTemplate(infoItems, searchValue), document.querySelector('.container'));
      }

      e.target.previousElementSibling.value = '';
   }
   
   async function getData() {
      const response = await fetch('http://localhost:3030/jsonstore/advanced/table');
      const data = await response.json();

      return Object.values(data);   
   }

   function doesMatch(item, toFind) {

      let isFound = Object.values(item).map(i => i.toLowerCase()).filter(x => x.includes(toFind));

      if (isFound.length == 0) {
         return false;
      }

      return true;
   }
}

solve();