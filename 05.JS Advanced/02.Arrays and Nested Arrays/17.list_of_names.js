function getList(input) {
    let arr = input.map(x => String(x));
    let result = [];

    result = arr.sort((a,b) => a.localeCompare(b));

    for (let i = 0; i < result.length; i++) {
        
        console.log(`${i + 1}.${result[i]}`);
        
    }
}

getList(["John", "Bob", "Christina", "Ema"]);