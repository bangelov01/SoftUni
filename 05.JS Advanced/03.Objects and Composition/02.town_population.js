function createRegistry(cityInfo) {
    const cities = cityInfo.reduce((result, item) => {

        let [name, population] = item.split(` <-> `);
        population = Number(population);

        if (result[name] !== undefined) {
            population += result[name];
        }

        result[name] = population;

        return result;
        
    }, {});

    for (const city in cities) {

        console.log(`${city} : ${cities[city]}`);
    }
}

createRegistry(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']);