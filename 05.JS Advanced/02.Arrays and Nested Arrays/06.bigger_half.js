function getHalf(input) {
    const result = input.map(x => Number(x)).sort((a,b) => a - b).slice(input.length/2);

    return result;
}

getHalf([3, 19, 14, 7, 2, 19, 6])