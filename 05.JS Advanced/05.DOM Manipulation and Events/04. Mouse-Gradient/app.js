function attachGradientEvents() {
    let gradientElement = document.querySelector(`#gradient`);
    gradientElement.addEventListener(`mousemove`, move);
    gradientElement.addEventListener(`mouseout`, out);

    function move(e) {
        let number = e.offsetX / (e.target.clientWidth - 1);
        number = Math.trunc(number * 100);
        document.getElementById(`result`).textContent = number + `%`;
    }

    function out(e) {
        document.getElementById(`result`).textContent = ``;
    }
}