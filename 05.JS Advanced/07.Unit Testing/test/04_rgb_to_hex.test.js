const assert = require(`chai`).assert;
const rgbToHexColor = require(`../04_rgb_to_hex`);

describe(`Test isSymmetric functionality`, () => {

    it(`Should return color in hexadecimal format`, () => {
        let input1 = 20;
        let input2 = 50;
        let input3 = 40;

        let expected = `#143228`

        let result = rgbToHexColor(input1,input2,input3);

        assert.equal(result,expected);

    });

    it(`Should return color if input equals 0`, () => {
        let input1 = 0;
        let input2 = 50;
        let input3 = 40;

        let expected = `#003228`

        let result = rgbToHexColor(input1,input2,input3);

        assert.equal(result,expected);

    });

    it(`Should return color if input equals 255`, () => {
        let input1 = 255;
        let input2 = 50;
        let input3 = 40;

        let expected = `#FF3228`

        let result = rgbToHexColor(input1,input2,input3);

        assert.equal(result,expected);

    });

    it(`Should add zero infront of result when values are small`, () => {
        let input1 = 1;
        let input2 = 1;
        let input3 = 1;

        let expected = `#010101`;

        let result = rgbToHexColor(input1,input2,input3);

        assert.equal(result, expected);

    });

    it(`Should return undefined`, () => {

        assert.isUndefined(rgbToHexColor(-20,50,40));
        assert.isUndefined(rgbToHexColor(20,-50,40));
        assert.isUndefined(rgbToHexColor(20,50,-40));

        assert.isUndefined(rgbToHexColor(256,50,40));
        assert.isUndefined(rgbToHexColor(20,256,40));
        assert.isUndefined(rgbToHexColor(20,50,256));

        assert.isUndefined(rgbToHexColor(`20`,50,40));
        assert.isUndefined(rgbToHexColor(-20,`50`,40));
        assert.isUndefined(rgbToHexColor(-20,50,`40`));

    });
});