function solve() {

  let inputElement = document.querySelector(`#exercise textarea`);
  let generateButtonElement = document.querySelectorAll(`#exercise button`)[0];
  let buyButtonElement = document.querySelectorAll(`#exercise button`)[1];
  let tbodyElement = document.querySelector(`tbody`);

  generateButtonElement.addEventListener(`click`, () => {

    let inputArr = JSON.parse(inputElement.value);

    let itemsArrSafe = Array.from(inputArr);

    let neededTr = document.querySelector(`tbody tr`);

    for (const element of itemsArrSafe) {

      let tr = neededTr.cloneNode(true);
      tr.querySelector(`td img`).src = element.img;
      tr.children[1].children[0].textContent = element.name;
      tr.children[2].children[0].textContent = element.price;
      tr.children[3].children[0].textContent = element.decFactor;
      tr.querySelector(`td input`).removeAttribute("disabled");
      tbodyElement.appendChild(tr);
    }
  });

  buyButtonElement.addEventListener(`click`, () => {
    let checkedItems = Array.from(document.querySelectorAll(`tbody tr`))
    .filter(el => el.querySelector(`input:checked`));

    let names = checkedItems
    .map(el => el.querySelector(`td:nth-of-type(2) p`).textContent)
    .join(`, `);

    let prices = checkedItems
    .map(el => Number(el.querySelector(`td:nth-of-type(3) p`).textContent));

    let decFactors = checkedItems
    .map(el => Number(el.querySelector(`td:nth-of-type(4) p`).textContent));

    let totalPrice = prices.reduce((acc,el) => acc + el, 0).toFixed(2);
    let average = decFactors.reduce((acc,el) => acc + el,0) / decFactors.length;

    let finalText = `Bought furniture: ${names}\nTotal price: ${totalPrice}\nAverage decoration factor: ${average}`;

    document.querySelectorAll(`#exercise textarea`)[1].value = finalText;
  });
}