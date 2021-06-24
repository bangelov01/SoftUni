class Parking {
    constructor(capacity, vehicles = []) {
        this.capacity = Number(capacity);
        this.vehicles = vehicles;
    }

    addCar(carModel, carNumber) {

        if (this.vehicles.length >= this.capacity) {
            throw new Error("Not enough parking space.");
        }

        this.vehicles.push({ carModel, carNumber, payed: false });

        return `The ${carModel}, with a registration number ${carNumber}, parked.`

    }

    removeCar(carNumber) {

        let neededCar = this.vehicles.filter(el => el.carNumber == carNumber);

        if (neededCar.length == 0) {
            throw new Error("The car, you're looking for, is not found.");
        }
        if (neededCar[0].payed == false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }

        this.vehicles = this.vehicles.filter(el => el.carNumber !== carNumber);

        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {

        let neededCar = this.vehicles.filter(el => el.carNumber == carNumber);

        if (neededCar.length == 0) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }
        if (neededCar[0].payed == true) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        neededCar[0].payed = true;

        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {

        if (!carNumber) {
            let output = `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`;
            this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel));

            for (const vehicle of this.vehicles) {

                output += `\n${vehicle.carModel} == ${vehicle.carNumber} - ${vehicle.payed == true ? `Has payed` : `Not payed`}`;
            }
            return output.trim();
        }


        let neededCar = this.vehicles.filter(el => el.carNumber == carNumber);

        return `${neededCar[0].carModel} == ${neededCar[0].carNumber} - ${neededCar[0].payed == true ? `Has payed` : `Not payed`}`;
    }
}