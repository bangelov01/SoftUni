function factory(object) {

    let getEngine = (power) => {
        const engines = [
            {
                power: 90,
                volume: 1800
            },
            {
                power: 120,
                volume: 2400
            },
            {
                power: 200,
                volume: 3500
            }
        ];

        return engines.find(engine => engine.power >= power);
    }

    let getCarriage = (carriage, color) => {

        return {
            type: carriage,
            color: color
        }
    };

    let getWheels = (wheelSize) => {
        let wheel = Math.floor(wheelSize) % 2 === 0 ? Math.floor(wheelSize) - 1 : Math.floor(wheelSize);

        return Array(4).fill(wheel,0,4);
    };

  
    return {
        model: object.model,
        engine: getEngine(object.power),
        carriage: getCarriage(object.carriage, object.color),
        wheels: getWheels(object.wheelsize)
    };
}


const car = factory({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 });

console.log(car);
