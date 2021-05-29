function createCity(name, population, treasury) {
    
    const city = {
        name: String(name),
        population: Number(population),
        treasury: Number(treasury)
    }

    return city;
}

console.log(createCity('Tortuga',
7000,
15000));