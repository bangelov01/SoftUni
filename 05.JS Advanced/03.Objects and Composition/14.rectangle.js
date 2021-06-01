function rectangle(inputWidth, inputHeight, inputColor) {

    let rec = {
        width: Number(inputWidth),
        height: Number(inputHeight),
        color: inputColor.charAt(0).toUpperCase() + inputColor.slice(1),
        calcArea: () => { return Number(rec.width * rec.height)}
    }

    return rec;
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());