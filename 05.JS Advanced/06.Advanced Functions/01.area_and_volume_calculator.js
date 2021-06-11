function solve(area,vol,input) {

    let arr = JSON.parse(input);
    let result = [];

    for (const object of arr) {
        result.push({
            area: area.call(object),
            volume: vol.call(object)
        });
    }

    return result;
    
};

solve(area, vol, '[{"x":"1","y":"2","z":"10"},{"x":"7","y":"7","z":"10"},{"x":"5","y":"2","z":"10"}]')

function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};