function sort(arr,arg) {

    arr = arr.map(x => Number(x));
    
    const sorter = {
        asc: () => {
            arr.sort((a,b) => a - b);
        },
        desc: () => {
            arr.sort((a,b) => b - a)
        }
    }

    sorter[arg]();

    return arr;
}

console.log(sort([14, 7, 17, 6, 8], 'desc'));