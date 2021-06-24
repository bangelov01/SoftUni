class ChristmasDinner {
    constructor(budget, dishes=[], products=[], guests={}) {
        this.budget = Number(budget);
        this.dishes = dishes;
        this.products = products;
        this.guests = guests;
    }

    get budget() {
        return this._budget;
    }
    set budget(value) {
        if (value < 0) {
            throw new Error("The budget cannot be a negative number");
        }
        this._budget = value;
    }

    shopping(productInfoArray) {

        let product = productInfoArray[0];
        let price = Number(productInfoArray[1]);

        if (this.budget < price) {
            throw new Error("Not enough money to buy this product");
        }

        this.products.push(product);
        this.budget -= price;
        return `You have successfully bought ${product}!`;
    }

    recipes(objectRecipe) {

        let recipeName = objectRecipe.recipeName;
        let products = objectRecipe.productsList;
        let isMissing = false;

        for (const product of products) {
            
            if (!this.products.includes(product)) {
                isMissing = true;
                break;
            }
        }

        if (isMissing) {
            throw new Error("We do not have this product");
        }

        this.dishes.push(objectRecipe);
        return `${recipeName} has been successfully cooked!`
    }

    inviteGuests(name, dish) {

        let neededDish = this.dishes.filter(el => el.recipeName == dish);
        if (neededDish.length == 0) {
            throw new Error("We do not have this dish");
        }
        if (this.guests[name]) {
            throw new Error("This guest has already been invited"); //potential problem
        }
        this.guests[name] = dish;

        return `You have successfully invited ${name}!`
    }

    showAttendance() {

        let result = ``;

        for (const guest in this.guests) {
            result += `${guest} will eat ${this.guests[guest]}, which consists of `;
            let neededProducts = this.dishes.filter(el => el.recipeName == this.guests[guest]);

            result += neededProducts[0].productsList.join(`, `) + `\n`;
        }

        return result.trim();
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
