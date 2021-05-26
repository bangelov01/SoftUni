function action(array) {
    let number = 0;
    const result = [];

    for (const command of array) {
        
        if (command == `add`) {
            number++;
            result.push(number);
        }
        else if (command == `remove`) {
            number++;
            result.pop();
        }
    }

    if (result.length == 0) {
        console.log(`Empty`);
    }
    else{

        result.forEach(x => console.log(x));
    }
}

action(['add', 
'add', 
'remove', 
'add', 
'add']
)