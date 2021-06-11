function solution() {

    const recipeRequirements = getRequirements();

    let storage = getStorage();

    return function (input) {

        let inputArr = input.split(` `);

        let result = inputCase();
        let output = result[inputArr[0]]();

        
        return output;

        function inputCase() {

            return {
                restock: () => {
                    storage[inputArr[1]] += Number(inputArr[2]);
                    return `Success`;
                },
                prepare: () => {
                    let neededRecipe = recipeRequirements[inputArr[1]];
                    let quantity = inputArr[2];

                    for (const key in neededRecipe) {

                        if (neededRecipe[key] * quantity > storage[key] ||
                            !storage.hasOwnProperty(key)) {
                            return `Error: not enough ${key} in stock`;
                        }
                        storage[key] -= neededRecipe[key] * quantity;
                    }

                    return `Success`;
                },
                report: () => {

                    let str = ``;
                    for (const key in storage) {
                        str += `${key}=${storage[key]} `;
                    }

                    return str.trimEnd();
                }
            }
        }
    }

    function getRequirements() {
        return {
            apple: {
                carbohydrate: 1,
                flavour: 2
            },
            lemonade: {
                carbohydrate: 10,
                flavour: 20
            },
            burger: {
                carbohydrate: 5,
                fat: 7,
                flavour: 3

            },
            eggs: {
                protein: 5,
                fat: 1,
                flavour: 1
            },
            turkey: {
                protein: 10,
                carbohydrate: 10,
                fat: 10,
                flavour: 10
            }
        }
    }

    function getStorage() {
        return {
            protein: 0,
            carbohydrate: 0,
            fat: 0,
            flavour: 0
        }
    }
}

let manager = solution();
console.log(manager("restock flavour 50"));
console.log(manager("prepare lemonade 4"));
console.log(manager("report"));
