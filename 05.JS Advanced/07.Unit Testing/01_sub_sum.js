function sumElements(arr, startIndex, endIndex){
    if (Array.isArray(arr) == false) {
        return NaN;
    }

    let mappedArr = arr.map(x => Number(x));

    if (startIndex < 0) {
        startIndex = 0;
    }
    if (endIndex > arr.length - 1) {
        endIndex = arr.length - 1;
    }

    return mappedArr.slice(startIndex, endIndex + 1).reduce((acc,el) => acc + el,0);
}
console.log(sumElements([10, 'twenty', 30, 40], 0, 2));