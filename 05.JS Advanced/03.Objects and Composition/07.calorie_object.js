function combineCalories(input){

    const product = {};

    input.forEach((element,index) => {
        if (index % 2 == 0) {
            product[element] = Number(input[index + 1]);
        }
    });

    return product;
}

combineCalories(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);