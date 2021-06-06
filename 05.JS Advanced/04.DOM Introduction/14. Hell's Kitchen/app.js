function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {

      let textElement = document.querySelector(`textarea`);
      let restaurantArr = JSON.parse(textElement.value);
      let bestRestaurantElement = document.querySelector(`#bestRestaurant>p`);
      let bestWorkersElement = document.querySelector(`#workers>p`);

      let best = findBestRestaurant(restaurantArr);

      bestRestaurantElement.textContent = `Name: ${best.name} Average Salary: ${best.avgSalary.toFixed(2)} Best Salary: ${best.maxSalary.toFixed(2)}`;
      let workersMap = best.workers.map(w => `Name: ${w.worker} With Salary: ${w.salary}`).join(' ');
      bestWorkersElement.textContent = workersMap;

      function findBestRestaurant(arr){
         let resultRest = arr.reduce((acc, el) => {
            let [restaurant, ...workers] = el.split(/(?: - )|(?:, )/g);
            workers = workers.map(w => {
               let [worker, salary] = w.split(` `);

               return {
                  worker: worker,
                  salary: Number(salary)
               };
            });

            let foundRestaurant = acc.find(r => r.name === restaurant);
            if (foundRestaurant) {
               foundRestaurant.workers = foundRestaurant.workers.concat(workers);
            }
            else{
               acc.push({
                  name: restaurant,
                  workers: workers
               });
            }

            return acc;
         }, []);

         resultRest.forEach((el,i) => {
            el.inputOrder = i;
            el.avgSalary = el.workers.reduce((acc, el) => acc + el.salary, 0) / el.workers.length;
            el.maxSalary = Math.max(...el.workers.map(w => w.salary));
         });

         resultRest.sort((a,b) => b.avgSalary - a.avgSalary || a.inputOrder - b.inputOrder);
         let bestRestaurant = resultRest[0];
         bestRestaurant.workers.sort((a,b) => b.salary - a.salary);

         return bestRestaurant;
      }
   }
}