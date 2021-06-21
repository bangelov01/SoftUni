function solve(juices) {

    let juiceMap = new Map;
    let formedBottles = {};

    for (let i = 0; i < juices.length; i++) {

        let [juice, quantity] = juices[i].split(` => `);

        if (!juiceMap.has(juice)) {
            juiceMap.set(juice, 0);
        }

        juiceMap.set(juice, juiceMap.get(juice) + Number(quantity));

        while (juiceMap.get(juice) >= 1000) {

            juiceMap.set(juice, juiceMap.get(juice) - 1000);
            if (!formedBottles.hasOwnProperty(juice)) {
                formedBottles[juice] = 0;
            }
            formedBottles[juice]++;
            
        }
    }

    let result = Object.entries(formedBottles);

    for (const bottle of result) {
        
        console.log(`${bottle[0]} => ${bottle[1]}`);
    }
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789'])