function solve() {
   let createButtonElement = document.querySelector(`.btn.create`);
   let archiveRepo = [];

   createButtonElement.addEventListener(`click`, (e) => {

      e.preventDefault();

      let authorValue = document.querySelector(`#creator`).value;
      let titleValue = document.querySelector(`#title`).value;
      let categoryValue = document.querySelector(`#category`).value;
      let contentValue = document.querySelector(`#content`).value;

      createArticleElement();

      document.querySelector(`#creator`).value = ``;
      document.querySelector(`#title`).value = ``;
      document.querySelector(`#category`).value = ``;
      document.querySelector(`#content`).value = ``;

      function createArticleElement() {

         let parent = document.querySelector(`.site-content main section:first-child`);
         let article = document.createElement(`article`);

         let h1 = document.createElement(`h1`);
         h1.textContent = titleValue;

         let pCategory = document.createElement(`p`);
         pCategory.textContent = `Category:`;
         let strongCategory = document.createElement(`strong`);
         strongCategory.textContent = categoryValue;
         pCategory.appendChild(strongCategory);

         let pCreator = document.createElement(`p`);
         pCreator.textContent = `Creator:`;
         let strongCreator = document.createElement(`strong`);
         strongCreator.textContent = authorValue;
         pCreator.appendChild(strongCreator);

         let pText = document.createElement(`p`);
         pText.textContent = contentValue;

         let div = document.createElement(`div`);
         div.classList.add(`buttons`);
         let buttonDelete = document.createElement(`button`);
         buttonDelete.classList.add(`btn`);
         buttonDelete.classList.add(`delete`);
         buttonDelete.textContent = `Delete`;
         buttonDelete.addEventListener(`click`, (e) => {
            e.target.parentElement.parentElement.remove();
         })
         let buttonArchive = document.createElement(`button`);
         buttonArchive.classList.add(`btn`);
         buttonArchive.classList.add(`archive`);
         buttonArchive.textContent = `Archive`;
         buttonArchive.addEventListener(`click`, (e) => {
            let neededName = e.target.parentElement.parentElement.children[0].textContent;
            e.target.parentElement.parentElement.remove();
            archiveRepo.push(neededName);
            archiveRepo.sort((a,b) => a.localeCompare(b));
            let archiveElement = document.querySelector(`.archive-section ol:last-child`);
            archiveElement.innerHTML = ``;

            for (const title of archiveRepo) {
               let li = document.createElement(`li`);
               li.textContent = title;
               archiveElement.appendChild(li);
            }
         })
         div.appendChild(buttonDelete);
         div.appendChild(buttonArchive);

         article.appendChild(h1);
         article.appendChild(pCategory);
         article.appendChild(pCreator);
         article.appendChild(pText);
         article.appendChild(div);

         parent.appendChild(article);
      }
   })
}
