function search() {
   let listElements = document.querySelectorAll(`#towns li`);
   let searchValue = document.querySelector(`#searchText`).value;
   let matches = 0;

   let arrayElements = Array.from(listElements);

   arrayElements.forEach(x => {
      x.style.textDecoration = "none";
      x.style.fontWeight = "normal";
   });

   for (const element of arrayElements) {

      if (element.textContent.includes(searchValue)) {
         element.style.textDecoration = "underline";
         element.style.fontWeight = "bold";
         matches++;
      }     
   }

   document.getElementById(`result`).textContent = `${matches} matches found`
}
