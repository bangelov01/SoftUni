function sort(input) {
    const arr = [];

    for (const num of input) {
        if (num < 0) {
            arr.unshift(num);
        }
        else{
            arr.push(num);
        }
    }

    for (const num of arr) {
        console.log(num);
    }
}

sort([3, -2, 0, -1]);