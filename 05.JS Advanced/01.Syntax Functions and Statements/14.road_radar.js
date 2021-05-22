function getSpeedLimit(param1, param2){

    let speed = Number(param1);
    let location = String(param2);

    let status = ``;
    let limit = 0;

    switch (location) {
        case `motorway`:
            limit = 130;
            break;
        case `interstate`:
            limit = 90;
            break;
        case `city`:
            limit = 50;
            break;
        case `residential`:
            limit = 20;
            break;
    }

    if (isInLimit(speed, limit)) {
        console.log(`Driving ${speed} km/h in a ${limit} zone`)
    }
    else{

        let overLimit = speed - limit;

        if (overLimit <= 20) {
            status = `speeding`;         
        }
        else if (overLimit > 20 && overLimit <= 40) {
            status = `excessive speeding`;
        }
        else{
            status = `reckless driving `;
        }

        console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - ${status}`)
    }

    function isInLimit(speed, limit){

        if (speed > limit) {
            return false;
        }
        return true;
    }
}