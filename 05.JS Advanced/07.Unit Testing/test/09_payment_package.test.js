const assert = require(`chai`).assert;
const PaymentPackage = require(`../09_payment_package`);

describe(`Test PaymentPackage functionality`, () => {

    describe(`Test constructor and getter/setter functionality`, () => {

        it(`Test constructor with invalid name`, () => {
            assert.throw(() => new PaymentPackage(1,1), Error, 'Name must be a non-empty string');
            assert.throw(() => new PaymentPackage([],1), Error, 'Name must be a non-empty string');
            assert.throw(() => new PaymentPackage(undefined,1), Error, 'Name must be a non-empty string');
            assert.throw(() => new PaymentPackage({},1), Error, 'Name must be a non-empty string');
            assert.throw(() => new PaymentPackage(null,1), Error, 'Name must be a non-empty string');
            assert.throw(() => new PaymentPackage(``,1), Error, 'Name must be a non-empty string');
        });
        it(`Test constructor with invalid value`, () => {
            assert.throw(() => new PaymentPackage(`asd`,-1), Error, 'Value must be a non-negative number');
            assert.throw(() => new PaymentPackage(`asd`,{}), Error, 'Value must be a non-negative number');
            assert.throw(() => new PaymentPackage(`asd`,[]), Error, 'Value must be a non-negative number');
            assert.throw(() => new PaymentPackage(`asd`,`1`), Error, 'Value must be a non-negative number');
            assert.throw(() => new PaymentPackage(`asd`,null), Error, 'Value must be a non-negative number');
            assert.throw(() => new PaymentPackage(`asd`,undefined), Error, 'Value must be a non-negative number');
        });

        let result;

        beforeEach(() => {
            result = new PaymentPackage(`asd`,0);
        });
        afterEach(() => {
            result = null;
        });

        it(`Test constructor with valid inputs`, () => {
            assert.include(result, {name: `asd`, value: 0, VAT: 20, active: true});
        });
        it(`Test name getter`, () => {
            let expected = `asd`;

            assert.strictEqual(result.name, expected);
        });
        it(`Test value getter`, () => {
            let expected = 0;

            assert.strictEqual(result.value, expected);
        });
        it(`Test VAT getter`, () => {
            let expected = 20;

            assert.strictEqual(result.VAT, expected);
        });
        it(`Test active getter`, () => {
            let expected = true;

            assert.strictEqual(result.active, expected);
        });
        it(`Test name setter with invalid input`, () => {
            assert.throws(() => result.name = 1, Error, 'Name must be a non-empty string');
            assert.throws(() => result.name = ``, Error, 'Name must be a non-empty string');
            assert.throws(() => result.name = null, Error, 'Name must be a non-empty string');
            assert.throws(() => result.name = undefined, Error, 'Name must be a non-empty string');
            assert.throws(() => result.name = {}, Error, 'Name must be a non-empty string');
            assert.throws(() => result.name = [], Error, 'Name must be a non-empty string');

        });
        it(`Test value setter with invalid input`, () => {
            assert.throws(() => result.value = `1`, Error, 'Value must be a non-negative number');
            assert.throws(() => result.value = -1, Error, 'Value must be a non-negative number');
            assert.throws(() => result.value = null, Error, 'Value must be a non-negative number');
            assert.throws(() => result.value = undefined, Error, 'Value must be a non-negative number');
            assert.throws(() => result.value = {}, Error, 'Value must be a non-negative number');
            assert.throws(() => result.value = [], Error, 'Value must be a non-negative number');

        });
        it(`Test VAT setter with invalid input`, () => {
            assert.throws(() => result.VAT = `1`, Error, 'VAT must be a non-negative number');
            assert.throws(() => result.VAT = -1, Error, 'VAT must be a non-negative number');
            assert.throws(() => result.VAT = null, Error, 'VAT must be a non-negative number');
            assert.throws(() => result.VAT = undefined, Error, 'VAT must be a non-negative number');
            assert.throws(() => result.VAT = {}, Error, 'VAT must be a non-negative number');
            assert.throws(() => result.VAT = [], Error, 'VAT must be a non-negative number');

        });
        it(`Test active setter with invalid input`, () => {
            assert.throws(() => result.active = `1`, Error, 'Active status must be a boolean');
            assert.throws(() => result.active = 0, Error, 'Active status must be a boolean');
            assert.throws(() => result.active = null, Error, 'Active status must be a boolean');
            assert.throws(() => result.active = undefined, Error, 'Active status must be a boolean');
            assert.throws(() => result.active = {}, Error, 'Active status must be a boolean');
            assert.throws(() => result.active = [], Error, 'Active status must be a boolean');

        });

        it(`Test name setter with valid input`, () => {
            assert.strictEqual(result.name = `pesho`, `pesho`);
            assert.strictEqual(result.name = ` `, ` `);
            assert.strictEqual(result.name = `1`, `1`);
        });
        it(`Test value setter with valid input`, () => {
            assert.strictEqual(result.value = 1, 1);
            assert.strictEqual(result.value = 0.5, 0.5);
            assert.strictEqual(result.value = 0, 0);
        });
        it(`Test VAT setter with valid input`, () => {
            assert.strictEqual(result.VAT = 1, 1);
            assert.strictEqual(result.VAT = 0.5, 0.5);
            assert.strictEqual(result.VAT = 0, 0);
        });
        it(`Test active setter with valid input`, () => {
            assert.strictEqual(result.active = true, true);
            assert.strictEqual(result.active = false, false);
        });
    });

    describe(`Test toString() functionality`, () => {

        it(`Test return with active status true`, () => {
            let result1 = new PaymentPackage(`dudi`,100);
            let test = [
                `Package: ${result1.name}` + (result1.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${result1.value}`,
                `- Value (VAT ${result1.VAT}%): ${result1.value * (1 + result1.VAT / 100)}`
            ];

            let expected = test.join(`\n`);

            assert.strictEqual(result1.toString(), expected);
        });
        it(`Test return with active status false`, () => {
            let result1 = new PaymentPackage(`dudi`,100);
            result1.active = false;
            let test = [
                `Package: ${result1.name}` + (result1.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${result1.value}`,
                `- Value (VAT ${result1.VAT}%): ${result1.value * (1 + result1.VAT / 100)}`
            ];

            let expected = test.join(`\n`);

            assert.strictEqual(result1.toString(), expected);
        })
    })
})