class List {

    constructor() {
        this.array = [];
        this.size = 0;
    }

    add(element) {
        this.array.push(element);
        this.size++;
        return this.array.sort((a,b) => a - b);;
    }

    remove(index) {

        if (index >= this.array.length || index < 0) {
            throw new Error(`Index is out of range!`);
        }
        this.array.splice(index, 1);
        this.size--;
        return this.array.sort((a,b) => a - b);;
    }

    get(index) {

        if (index >= this.array.length || index < 0) {
            throw new Error(`Index is out of range!`);
        }
        
        return this.array[index];
    }
}


let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size);