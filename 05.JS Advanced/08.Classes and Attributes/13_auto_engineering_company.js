function solve(carArray) {

    let carMap = new Map;

    for (let i = 0; i < carArray.length; i++) {
        let [carBrand, carModel, producedCars] = carArray[i].split(` | `);

        if (!carMap.has(carBrand)) {
            carMap.set(carBrand, new Map);
        }
        let innerModels = carMap.get(carBrand);
        if (!innerModels.has(carModel)) {
            innerModels.set(carModel,0);
        }
        let innerBrand = innerModels.get(carModel);
        innerModels.set(carModel, innerBrand + Number(producedCars));
    }

    for (const brand of carMap.keys()) {
        console.log(brand);
        let models = carMap.get(brand);
        for (const model of models.keys()) {
            console.log(`###${model} -> ${models.get(model)}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10'])