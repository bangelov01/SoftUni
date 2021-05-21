function func(stringOne, stringTwo, stringThree){

    let lengthSum = stringOne.length + 
    stringTwo.length + 
    stringThree.length;

    let average = Math.floor(lengthSum / 3);

    console.log(lengthSum);
    console.log(average);
}