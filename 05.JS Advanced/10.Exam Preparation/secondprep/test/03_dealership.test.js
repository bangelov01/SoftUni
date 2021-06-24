const assert = require(`chai`).assert;
const dealership = require(`../03_dealership`);

describe(`Test dealership object functionality`, () => {

    describe(`Test newCarCost() functionality`, () => {
        it(`Should return price with discount with existing car`, () => {
            assert.equal(dealership.newCarCost(`Audi A4 B8`,50000),35000);
            assert.equal(dealership.newCarCost('Audi A6 4K',50000),30000);
            assert.equal(dealership.newCarCost('Audi A8 D5',50000),25000);
            assert.equal(dealership.newCarCost('Audi TT 8J',50000),36000);
        })
        it(`Should return same price with non existing car`, () => {
            assert.equal(dealership.newCarCost(`Mazda 3`,50000),50000);
        })
    })
    describe(`Test carEquipment() functionality`, () => {
        it(`Should return extras with correct params`, () => {
            let extras = [`Air conditioner`, `Heated seats`, `Cruise control`];
            let indexes = [0, 2];
            assert.deepEqual(dealership.carEquipment(extras, indexes),[`Air conditioner`, `Cruise control`]);
        })
        it(`Should return undefined array with empty param`, () => {
            let extras = [];
            let indexes = [2];
            assert.deepEqual(dealership.carEquipment(extras, indexes),[undefined]);
        })
    })
    describe(`Test euroCategory() functionality`, () => {
        it(`Should return price category with less than 4`, () => {
            assert.strictEqual(dealership.euroCategory(0), 'Your euro category is low, so there is no discount from the final price!');
        })
        it(`Should return price category with equal than 4`, () => {
            assert.equal(dealership.euroCategory(4), `We have added 5% discount to the final price: 14250.`);
        })
        it(`Should return price category with more than 4`, () => {
            assert.equal(dealership.euroCategory(10), `We have added 5% discount to the final price: 14250.`);
        })
    })
})