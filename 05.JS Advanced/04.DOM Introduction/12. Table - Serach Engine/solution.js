function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let rowsElements = document.querySelectorAll(`tbody tr`);
      let inputElementValue = document.querySelector(`#searchField`).value;
      let rowsArray = Array.from(rowsElements);

      rowsArray.forEach(x => x.removeAttribute(`class`));

      for (const row of rowsArray) {

         for (let i = 0; i < row.children.length; i++) {
            
            if (row.children[i].textContent.includes(inputElementValue) && inputElementValue !== ``) {
               row.classList.add(`select`);
            }
         }
      }
   }
}