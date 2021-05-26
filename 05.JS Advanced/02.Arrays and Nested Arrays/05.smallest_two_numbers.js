function getSmallestElements(input) {
    const result = input.map(x => Number(x)).sort((a,b) => a - b);

    console.log(result[0] +` `+result[1]);  
}

getSmallestElements([3, 0, 10, 4, 7, 3])