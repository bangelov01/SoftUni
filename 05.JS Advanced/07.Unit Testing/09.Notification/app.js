function notify(message) {

  let requiredDivElement = document.getElementById(`notification`);

  requiredDivElement.textContent = message;
  requiredDivElement.style.display = `block`;

  requiredDivElement.addEventListener(`click`, (e2) => {
    e2.target.style.display = `none`;
  });
}