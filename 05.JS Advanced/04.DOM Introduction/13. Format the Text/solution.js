function solve() {
  let textAreaElement = document.querySelector(`#input`);
  let textToWorkOn = textAreaElement.value;
  let outputElement = document.querySelector(`#output`);

  let textArray = textToWorkOn.split(`.`).filter(i => i);

  let paragraph = document.createElement(`p`);
  let sentanceCount = 0;

  for (let i = 0; i < textArray.length; i++) {

    paragraph.textContent += textArray[i] + `.`;
    sentanceCount++;

    if (sentanceCount == 3) {
      outputElement.appendChild(paragraph);
      paragraph = document.createElement(`p`);
      sentanceCount = 0;
    }
  }

  if (sentanceCount !== 0) {
    outputElement.appendChild(paragraph);
  }
}