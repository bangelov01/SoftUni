function solve(input, criteria) {
    
    let criteriaSplit = criteria.split(`-`);

    let employeesArr = JSON.parse(input);

    let result = employeesArr.filter(el => sortEmployees(el,criteriaSplit));

    function sortEmployees(employee, criteria){

        return employee[`${criteria[0]}`] === criteria[1];
    }

    result.forEach((el,i) => {
        console.log(`${i}. ${el["first_name"]} ${el["last_name"]} - ${el["email"]}`);
    })
}

solve(`[{
    "id": "1",
    "first_name": "Kaylee",
    "last_name": "Johnson",
    "email": "k0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Johnson",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  }, {
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }, {
    "id": "4",
    "first_name": "Evanne",
    "last_name": "Johnson",
    "email": "ev2@hostgator.com",
    "gender": "Male"
  }]`,
 'last_name-Johnson'
)