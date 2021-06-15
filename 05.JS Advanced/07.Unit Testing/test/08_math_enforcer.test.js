const assert = require(`chai`).assert;
const mathEnforcer = require(`../08_math_enforcer`);

describe(`Test mathEnforcer functionality`, () => {

    describe(`Test addFive() functionality`,() => {

        it(`Should return result plus five with correct input`, () => {

            assert.strictEqual(mathEnforcer.addFive(5), 10);
            assert.strictEqual(mathEnforcer.addFive(-5), 0);
            assert.closeTo(mathEnforcer.addFive(4.99), 10, 0.01);
            assert.closeTo(mathEnforcer.addFive(-4.99), 0.012, 0.01);
        });

        it(`Should return undefined in following cases`, () => {

            assert.isUndefined(mathEnforcer.addFive(`5`));
            assert.isUndefined(mathEnforcer.addFive(null));
            assert.isUndefined(mathEnforcer.addFive(undefined));
            assert.isUndefined(mathEnforcer.addFive({}));
            assert.isUndefined(mathEnforcer.addFive([]));
        });
    });

    describe(`Test subtractTen() functionality`,() => {

        it(`Should return result minus ten with correct input`, () => {

            assert.strictEqual(mathEnforcer.subtractTen(5), -5);
            assert.strictEqual(mathEnforcer.subtractTen(-5), -15);
            assert.closeTo(mathEnforcer.subtractTen(4.99), -5, 0.01);
            assert.closeTo(mathEnforcer.subtractTen(-4.99), -14.995, 0.01);
        });

        it(`Should return undefined in following cases`, () => {

            assert.isUndefined(mathEnforcer.subtractTen(`5`));
            assert.isUndefined(mathEnforcer.subtractTen(null));
            assert.isUndefined(mathEnforcer.subtractTen(undefined));
            assert.isUndefined(mathEnforcer.subtractTen({}));
            assert.isUndefined(mathEnforcer.subtractTen([]));
        });
    });

    describe(`Test sum() functionality`,() => {

        it(`Should return undefined in following cases`, () => {

            assert.isUndefined(mathEnforcer.sum(`asd`,1));
            assert.isUndefined(mathEnforcer.sum(null,1));
            assert.isUndefined(mathEnforcer.sum(undefined,1));
            assert.isUndefined(mathEnforcer.sum({},1));
            assert.isUndefined(mathEnforcer.sum([],1));

            assert.isUndefined(mathEnforcer.sum(1,`asd`));
            assert.isUndefined(mathEnforcer.sum(1,null));
            assert.isUndefined(mathEnforcer.sum(1, undefined));
            assert.isUndefined(mathEnforcer.sum(1, {}));
            assert.isUndefined(mathEnforcer.sum(1, []));
        });

        it(`Should return sum when both numbers are correct`, () => {

            assert.strictEqual(mathEnforcer.sum(1,1), 2);
            assert.strictEqual(mathEnforcer.sum(-1,1), 0);
            assert.strictEqual(mathEnforcer.sum(1,-1), 0);
            assert.strictEqual(mathEnforcer.sum(2.45,2.50), 4.95);
            assert.closeTo(mathEnforcer.sum(4.99,5.99),10.97,0.01);
        });
    }); 
});