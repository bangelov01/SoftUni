function toggle() {
    let buttonElement = document.querySelector(`.button`);
    let extraElement = document.querySelector(`#extra`);

    if (buttonElement.textContent == `More`) {
        extraElement.style.display = "block";
        buttonElement.textContent = `Less`;
    }
    else if (buttonElement.textContent == `Less`) {
        extraElement.style.display = "none";
        buttonElement.textContent = `More`;
    }
}