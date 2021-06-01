function toJson(input){

    let table = [];
    let tableHeadings = input[0]
    .split(/\s*\|\s*/g)
    .filter(x => x !== ``)
    .map(x => isNaN(Number(x)) ? x : Number(Number(x).toFixed(2)));

    for (let i = 1; i < input.length; i++) {
        let [city, lattitude, longitude] = input[i].split(/\s*\|\s*/g)
        .filter(x => x !== ``);
        lattitude = Number(Number(lattitude).toFixed(2));
        longitude = Number(Number(longitude).toFixed(2));
        
        let entity = {};
        entity[tableHeadings[0]] = city;
        entity[tableHeadings[1]] = lattitude;
        entity[tableHeadings[2]] = longitude;

        table.push(entity);
    }

    return JSON.stringify(table);
}

let obj = toJson(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |'])

console.log(obj);