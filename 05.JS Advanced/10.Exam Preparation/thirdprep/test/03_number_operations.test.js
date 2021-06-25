const assert = require(`chai`).assert;
const numberOperations = require(`../03_number_operations`);

describe(`Test numberOperations functionality`, () => {

    describe(`Test powNumber() functionality`, () => {

        it(`Should return NaN with wrong parameter`, () => {
            assert.isNaN(numberOperations.powNumber(`asd`));
        })
        it(`Should return result with right parameter`, () => {
            assert.strictEqual(numberOperations.powNumber(`2`), 4);
            assert.strictEqual(numberOperations.powNumber(2), 4);
        })
    })
    describe(`Test numberChecker() functionality`, () => {

        it(`Should return error with wrong parameter`, () => {
            assert.throw(() => numberOperations.numberChecker(`asd`), Error, 'The input is not a number!');
            assert.throw(() => numberOperations.numberChecker(undefined), Error, 'The input is not a number!');
        })
        it(`Should return result with right parameter below 100`, () => {
            assert.strictEqual(numberOperations.numberChecker(50), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(99), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(-10), 'The number is lower than 100!');
        })
        it(`Should return result with right parameter equal or above 100`, () => {
            assert.strictEqual(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');
            assert.strictEqual(numberOperations.numberChecker(600), 'The number is greater or equal to 100!');
        })
    })

    describe(`Test sumArrays() functionality`, () => {

        it(`Test with equal arrays`, () => {
            assert.deepEqual(numberOperations.sumArrays([1,2,3],[1,2,3]), [2,4,6])
        })
        it(`Test with first array longer`, () => {
            assert.deepEqual(numberOperations.sumArrays([1,2,3,4],[1,2,3]), [2,4,6,4])
        })
        it(`Test with second array longer`, () => {
            assert.deepEqual(numberOperations.sumArrays([1,2,3],[1,2,3,4]), [2,4,6,4])
        })
        it(`Test with one integer in array`, () => {
            assert.deepEqual(numberOperations.sumArrays([1],[1]), [2])
        })
        it(`Test with two integer in array`, () => {
            assert.deepEqual(numberOperations.sumArrays([1,1],[1,1]), [2,2])
        })
    })
})