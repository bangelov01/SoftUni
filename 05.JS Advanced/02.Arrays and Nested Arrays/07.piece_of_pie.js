function getFlavors(flavors, targetFlavorOne, targetFlavorTwo) {
    let flavOneIndex = flavors.findIndex(x => x == targetFlavorOne);
    let flavTwoIndex = flavors.findIndex(x => x == targetFlavorTwo);

    const result = flavors.slice(flavOneIndex, flavTwoIndex + 1);

    console.log(result);
}

getFlavors(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie');