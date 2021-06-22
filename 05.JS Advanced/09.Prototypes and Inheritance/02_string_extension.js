(function solve() {

    String.prototype.ensureStart = function (str) {

        if (this.toString().startsWith(str)) {
            return this.toString();
        }

        let result = str + this.toString();
        return result;
    }

    String.prototype.ensureEnd = function (str) {

        if (this.toString().endsWith(str)) {
            return this.toString();
        }

        let result = this.toString() + str;
        return result;
    }

    String.prototype.isEmpty = function () {

        return this.length === 0 ? true : false;
    }

    String.prototype.truncate = function (n) {

        if (n <= 3) {
            return `.`.repeat(n);
        }
        if (this.toString().length <= n) {
            return this.toString();
        }

        let lastIndex = this.toString().substr(0, n - 2).lastIndexOf(` `);

        if (lastIndex != -1) {
            return this.toString().substr(0, lastIndex) + `...`;
        }
        
        return this.toString().substr(0, n - 3) + `...`;

    }

    String.format = function(str, ...params) {

        for (let i = 0; i < params.length; i++) {
            let index = str.indexOf(`{` + i + `}`);

            while (index != -1) {
                str = str.replace(`{` + i + `}`, params[i]);
                index = str.indexOf(`{` + i + `}`);
            }
        }

        return str;
    }
}) ();