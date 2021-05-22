function checkDigits(number) {

    let arr = number.toString().split(``).map(Number);
    let areSame = true;

    for (let i = 0; i < arr.length - 1; i++) {
        
        if (arr[i] != arr[i + 1]) {
            areSame = false;
            break;
        }        
    }

    let sum = arr.reduce((a,b) => a+b);

    if (areSame) {
        console.log(true);
    }  
    else{
        console.log(false);
    }

    console.log(sum)
}