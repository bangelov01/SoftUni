class Stringer {

    constructor(innerString , innerLength) {
        this.innerString = innerString;
        this.innerLength = Number(innerLength);
    }

    increase(length) {

        this.innerLength += Number(length);
    }

    decrease(length) {

        let val = this.innerLength - Number(length);

        if (val <= 0) {
            this.innerLength = 0;
        }
        else{
            this.innerLength = val;
        }
    }

    toString() {

        if (this.innerLength === 0) {
            return `...`;
        }
        else if (this.innerString.length >= this.innerLength) {
            return this.innerString.substring(0,this.innerString.length - this.innerLength) + `...`;
        }

        return this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
