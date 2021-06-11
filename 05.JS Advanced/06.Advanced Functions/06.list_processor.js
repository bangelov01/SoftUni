function solve(input) {

    let result = [];

    const processor = {
        add: (value) => {
            result.push(value);
        },
        remove: (value) => {
            result = result.filter(x => x !== value);
        },
        print: () => {
            console.log(result.join(`,`));
        }
    }

    for (const element of input) {
        let [command, value] = element.split(` `);

        if (value !== undefined) {
            processor[command](value);
        }
        else{
            processor[command]();
        }      
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print'])