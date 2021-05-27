function sort(input){

    let arr = input.map(x => Number(x)).sort((a,b) => a - b);
    let result = [];
    
    while (arr.length > 0) {

        let min = arr.shift();
        let max = arr.pop();

        if (max === undefined) {
            result.push(min);
            break;
        }
        result.push(min,max)  
    }
    console.log(result);
}

sort([1,65,2]);