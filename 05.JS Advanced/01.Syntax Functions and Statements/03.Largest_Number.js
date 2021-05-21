function findLargest(numberOne, numberTwo, numberThree){

    let result;

    if (numberOne > numberTwo && numberOne > numberThree) {
        result = numberOne;
    }
    else if (numberTwo > numberOne && numberTwo > numberThree) {
        result = numberTwo;
    }
    else{
        result = numberThree;
    }

    console.log('The largest number is ' + result + '.');
}