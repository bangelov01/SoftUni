const assert = require(`chai`).assert;
const sum = require(`../02_sum_of_numbers`);

describe(`Test sum functionality`, () => {

    it(`Should add positive numbers`, () => {

        let input = [1,2,3,4,5];
        let expected = input.reduce((a,b) => a + b,0);
    
        let result = sum(input);
    
        assert.strictEqual(result, expected)
    });
    
    it(`Should return false when adding positive numbers`, () => {
        let input = [1,2,3,4,5];
        let expected = 1234;
    
        let result = sum(input);
    
        assert.notEqual(result, expected);
    });
    
    it(`Should add negative numbers`, () => {
    
        let input = [-1,2,-3,4,-5];
        let expected = input.reduce((a,b) => a + b,0);
    
        let result = sum(input);
    
        assert.strictEqual(result, expected)
    });
    
    it(`Should return NaN if a string is present`, () => {
    
        let input = [-1,2,`asd`,4,-5];
    
        let result = sum(input);
    
        assert.isNaN(result);
    });
    
    it(`Should return zero with empty array`, () => {
    
        let input = [];
        let expected = input.reduce((a,b) => a + b,0);
    
        let result = sum(input);
    
        assert.strictEqual(result, expected)
    });

});