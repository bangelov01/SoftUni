const assert = require(`chai`).assert;
const isSymmetric = require(`../03_check_for_symmetry`);

describe(`Test isSymmetric functionality`, () => {

    it(`Should return true if array is equal`, () => {
        let input = [1,2,3,2,1];

        let result = isSymmetric(input);

        assert.isTrue(result);
    });

    it(`Should return false if array is not equal`, () => {
        let input = [1,2,3,2,1,1];

        let result = isSymmetric(input);

        assert.isFalse(result);
    });
    
    it(`Should return false if input is not array`, () => {
        let input = 1;

        let result = isSymmetric(input);

        assert.isFalse(result);
    });

    it(`Should return true if array is empty`, () => {
        let input = [];

        let result = isSymmetric(input);

        assert.isTrue(result);
    });

    it(`Should return false if array contains string`, () => {
        let input = [`1`,1];

        let result = isSymmetric(input);

        assert.isFalse(result);
    });

    it(`Should return true if only one element in array`, () => {
        let input = [1];

        let result = isSymmetric(input);

        assert.isTrue(result);
    });
});