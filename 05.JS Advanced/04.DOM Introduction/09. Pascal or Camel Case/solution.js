function solve() {

  let sentanceElement = document.querySelector(`#text`).value;
  let conventionElement = document.querySelector(`#naming-convention`).value;
  let result = ``;

  if (conventionElement == `Pascal Case`) {
    result = sentanceElement.toLowerCase()
      .split(` `)
      .map(x => x[0].toUpperCase() + x.slice(1))
      .join(``);
  }
  else if (conventionElement == `Camel Case`) {
    result = sentanceElement.toLowerCase()
      .split(` `)
      .map((x, i) => i !== 0 ? x[0].toUpperCase() + x.slice(1) : x)
      .join(``);
  }
  else {
    result = `Error!`;
  }

  document.querySelector(`#result`).textContent = result;

}