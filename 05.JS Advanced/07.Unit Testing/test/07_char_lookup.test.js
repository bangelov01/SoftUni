const assert = require(`chai`).assert;
const lookupChar = require(`../07_char_lookup`);

describe(`Test lookupChar functionality`, () => {

    it(`Should return index at string with valid input`, () =>{

        assert.equal(lookupChar(`asdf`,1), `s`);
        assert.equal(lookupChar(`asdf`,0), `a`);
    });

    it(`Should return undefined with invalid string`, () =>{

        assert.isUndefined(lookupChar(1,1));
        assert.isUndefined(lookupChar([],1));
        assert.isUndefined(lookupChar({},1));
        assert.isUndefined(lookupChar(null,1));
        assert.isUndefined(lookupChar(undefined,1));

    });

    it(`Should return undefined with invalid index`, () =>{

        assert.isUndefined(lookupChar(`asd`,`1`));
        assert.isUndefined(lookupChar(`asd`,2.5));
        assert.isUndefined(lookupChar(`asd`, null));
        assert.isUndefined(lookupChar(`asd`, undefined));
        assert.isUndefined(lookupChar(`asd`,[]));
        assert.isUndefined(lookupChar(`asd`,{}));

    });

    it(`Should return incorrect index with out of range index`, () =>{

        assert.equal(lookupChar(`asd`,3), `Incorrect index`);
        assert.equal(lookupChar(`asd`,4), `Incorrect index`);
        assert.equal(lookupChar(`asd`,-1), `Incorrect index`);
        assert.equal(lookupChar(``, 0), `Incorrect index`);

    });
});