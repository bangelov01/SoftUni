const assert = require(`chai`).assert;
const pizzUni = require(`../03_pizza_uni`);

describe(`Test pizzaUni functionality`, () => {

    describe(`Test makeAnOrder() functionaloity`, () => {

        let testObj = {};

        beforeEach(() => {
            testObj = {};
        });
        afterEach(() => {
            testObj = null;
        });

        it(`Should throw with missing .orderedPizza`,() => {
            assert.throw(() => pizzUni.makeAnOrder(testObj),Error, `You must order at least 1 Pizza to finish the order.`);
        });
        it(`Should throw with falsy .orderedPizza`,() => {
            testObj.orderedPizza = null;
            assert.throw(() => pizzUni.makeAnOrder(testObj),Error, `You must order at least 1 Pizza to finish the order.`);
        });
        it(`Should return with truthy .orderedPizza`, () => {
            testObj.orderedPizza = `margarita`;
            assert.equal(pizzUni.makeAnOrder(testObj), `You just ordered margarita`);
        })
        it(`Should return with drink with truthy .orderedDrink`, () => {
            testObj.orderedPizza = `margarita`;
            testObj.orderedDrink = `mohito`;
            assert.equal(pizzUni.makeAnOrder(testObj), `You just ordered margarita and mohito.`);
        })
        it(`Should return without drink with falsy .orderedDrink`, () => {
            testObj.orderedPizza = `margarita`;
            testObj.orderedDrink = ``;
            assert.equal(pizzUni.makeAnOrder(testObj), `You just ordered margarita`);
        })
    });
    describe(`Test getRemainingWork() functionaloity`, () => {

        let testObj = {};
        let testObj1 = {};

        beforeEach(() => {
            testObj = {};
            testObj1 = {};
        });
        afterEach(() => {
            testObj = null;
            testObj1 = null;
        });

        it(`Should return complete orders with empty arr`, () => {
            
            assert.equal(pizzUni.getRemainingWork([]), 'All orders are complete!');

        });
        it(`Should return complete orders with invalid arr`, () => {
            testObj.pizzaName = `margarita`;
            testObj.status = `idk`;
            assert.equal(pizzUni.getRemainingWork([]), 'All orders are complete!');
        });
        it(`Should return complete orders with ready status`, () => {
            testObj.pizzaName = `margarita`;
            testObj.status = `ready`;
            testObj1.pizzaName = `kalzone`;
            testObj1.status = `ready`;
            assert.equal(pizzUni.getRemainingWork([testObj, testObj1]), 'All orders are complete!');
        });
        it(`Should return preparing orders with preparing status one`, () => {
            testObj.pizzaName = `margarita`;
            testObj.status = `ready`;
            testObj1.pizzaName = `kalzone`;
            testObj1.status = `preparing`;
            assert.equal(pizzUni.getRemainingWork([testObj, testObj1]), `The following pizzas are still preparing: kalzone.`);
        });
        it(`Should return preparing orders with preparing status multiple`, () => {
            testObj.pizzaName = `margarita`;
            testObj.status = `preparing`;
            testObj1.pizzaName = `kalzone`;
            testObj1.status = `preparing`;
            assert.equal(pizzUni.getRemainingWork([testObj, testObj1]), `The following pizzas are still preparing: margarita, kalzone.`);
        });

    });
    describe(`Test orderType() functionaloity`, () => {
        it(`Should return totalSum with type delivery`, () => {
            assert.strictEqual(pizzUni.orderType(10,`Delivery`), 10);
        });
        it(`Should return totalSum plus discount with type Carry Out`, () => {
            let num = 10;
            num -= num * 0.1;
            assert.strictEqual(pizzUni.orderType(10,`Carry Out`), num);
        });
        // it(`Should return undefined with invalid order`, () => {
        //     assert.strictEqual(pizzUni.orderType(10,`Del`), undefined);
        // });
    });
});