class Company {

    constructor() {
        this.departments = {};
    }

    addEmployee(username, salary, position, department) {

        let args = Array.from(arguments);

        if (args.includes("") ||
            args.includes(null) ||
            args.includes(undefined)) {

            throw new Error(`Invalid input!`);
        }

        if (Number(arguments[1]) < 0) {

            throw new Error(`Invalid input!`);
        }

        let employee = {
            Name: username,
            Salary: Number(salary),
            Position: position
        }

        if (!this.departments.hasOwnProperty(department)) {

            this.departments[department] = [];
        }

        this.departments[department].push(employee);

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        
        let departments = Object.entries(this.departments);

        for (const department of departments) {
            
            department.averageSalary = department[1].reduce((acc,currVal) => {
                return acc + currVal[`Salary`];
            },0) / department[1].length;
        }

        departments.sort((a,b) => a.averageSalary + b.averageSalary);

        let bestDept = departments[0];
        let employees = Array.from(bestDept[1]);

        employees.sort((a,b) => b.Salary - a.Salary || a.Name.localeCompare(b.Name));


        let resultString = `Best Department is: ${bestDept[0]}\nAverage salary: ${bestDept.averageSalary.toFixed(2)}\n`;
        
        for (const employee of employees) {
            resultString += `${employee.Name} ${employee.Salary} ${employee.Position}\n`
        }

        return resultString.trimEnd();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
