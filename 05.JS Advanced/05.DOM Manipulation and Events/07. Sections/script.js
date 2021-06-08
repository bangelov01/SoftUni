function create(words) {
   let contentElement = document.getElementById(`content`);

   for (let i = 0; i < words.length; i++) {
      let newDiv = document.createElement(`div`);
      let newP = document.createElement(`p`);
      newP.textContent = words[i];
      newP.style.display = "none";
      newDiv.addEventListener(`click`, () =>{
         newP.style.display = "block";
      });
      
      newDiv.appendChild(newP);
      contentElement.appendChild(newDiv);
   }
}