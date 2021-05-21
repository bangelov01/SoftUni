function dayOfTheWeek(input) {
    let allowedArr = ['Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday'];

    if (allowedArr.includes(input)) {
        console.log(allowedArr.indexOf(input) + 1);
    }
    else{
        console.log('error');
    }
}