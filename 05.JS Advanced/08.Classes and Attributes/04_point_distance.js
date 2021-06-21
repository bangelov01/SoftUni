class Point {

    constructor(x, y){
        this.x = x;
        this.y = y;
    }

    static distance(pointOne, pointTwo) {

        let dx = pointTwo.x - pointOne.x;
        let dy = pointTwo.y - pointOne.y;


        return Math.sqrt(dx ** 2 + dy ** 2);
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));