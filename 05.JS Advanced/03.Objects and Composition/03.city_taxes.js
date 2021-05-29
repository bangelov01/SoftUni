function createCity(name, population, treasury) {
    
    const city = {
        name: String(name),
        population: Number(population),
        treasury: Number(treasury),
        taxRate: 10,
        collectTaxes: function(){
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth: function(percentage){
            this.population += Math.floor(this.population * (percentage/100));
        },
        applyRecession: function(percentage){
            this.treasury -= Math.floor(this.treasury * (percentage/100));
        }
    }
    return city;
}

const city =
createCity('Tortuga',
  7000,
  15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);