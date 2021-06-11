function solve(...args) {

    let obj = {};
    let result = [];

    args.forEach((el) => {

        console.log(`${typeof(el)}: ${el}`);

        if (!obj.hasOwnProperty(typeof(el))) {
            obj[typeof(el)] = 1;
        }
        else{
            obj[typeof(el)]++;
        }
    });

    result = Object.entries(obj);
    result.sort((a,b) => b[1] - a[1]);

    for (const el of result) {
        console.log(`${el[0]} = ${el[1]}`);
    }
}
solve('cat', 42, 43, function () { console.log('Hello world!'); })