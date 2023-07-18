function solve() {
  document.querySelector('#btnSend').addEventListener('click', onClick);
  let placesArr = [];
  function onClick() {
    let textJSON = document.querySelector(`textarea`).value;
    let dataArr = JSON.parse(textJSON);
    for (let str of dataArr) {
      let [name, ...strArr] = str.replace(` - `, `, `).split(`, `);
      let pairsArr = strArr.map(s => s.split(` `)).map(([name, number]) => [name, Number(number)]);
      let doesExist = false;
      for (let obj of placesArr) {
        if (obj.name === name) {
          obj.pairsArr = [...obj.pairsArr, ...pairsArr];
          doesExist = true;
          break;
        }
      }
      if (!doesExist) {
        placesArr.push({ name, pairsArr });
      }
    }
    let bestAvgSalary = 0;
    let bestPlace = {};
    for (let placeObj of placesArr) {
      let sum = 0;
      for (let [_, salary] of placeObj.pairsArr) {
        sum += salary;
      }
      let localAvgSalary = sum / placeObj.pairsArr.length;
      if (localAvgSalary > bestAvgSalary) {
        bestPlace = placeObj;
        bestAvgSalary = localAvgSalary;
      }
    }
    bestPlace.pairsArr.sort((a, b) => b[1] - a[1]);
    document.querySelector(`#bestRestaurant p`).textContent = `Name: ${bestPlace.name} Average Salary: ${bestAvgSalary.toFixed(2)} Best Salary: ${bestPlace.pairsArr[0][1].toFixed(2)}`;
    let workersArr = bestPlace.pairsArr.map(([name, salary]) => `Name: ${name} With Salary: ${salary}`);
    document.querySelector(`#workers p`).textContent = workersArr.join(` `);
  }
}