const assert = require(`chai`).assert;
const isOddOrEven = require(`../06_even_or_odd`);

describe(`Test isOddOrEven functionality`, () => {

    it(`Should return even when string length is even`, () => {

        assert.strictEqual(isOddOrEven(`aa`),`even`);
        assert.strictEqual(isOddOrEven(`bbbb`),`even`);

    });

    it(`Should return odd when string length is odd`, () => {

        assert.strictEqual(isOddOrEven(`a`),`odd`);
        assert.strictEqual(isOddOrEven(`bbb`),`odd`);

    });

    it(`Should return undefined`, () => {

        assert.strictEqual(isOddOrEven(1), undefined);
        assert.strictEqual(isOddOrEven(null), undefined);
        assert.strictEqual(isOddOrEven(undefined), undefined);
        assert.strictEqual(isOddOrEven([]), undefined);
        assert.strictEqual(isOddOrEven({}), undefined);
    });
});