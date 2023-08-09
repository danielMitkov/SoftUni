function solve(arr) {
  const n = Number(arr.shift());
  const entriesStrArr = arr.slice(0, n);
  const commands = arr.slice(n);
  const riders = [];
  for (let entry of entriesStrArr) {
    const [name, fuel, pos] = entry.split('|');
    if (Number(fuel) > 100) {
      fuel = '100';
    }
    riders.push({
      name,
      fuel: Number(fuel),
      pos: Number(pos)
    });
  }
  for (let action of commands) {
    if (action === 'Finish') {
      break;
    }
    const tokens = action.split(' - ');
    const riderName = tokens[1];
    if (tokens[0] === 'StopForFuel') {
      const minFuel = Number(tokens[2]);
      const changedPosition = Number(tokens[3]);
      const riderObj = riders.find(r => r.name === riderName);
      if (riderObj.fuel < minFuel) {
        riderObj.pos = changedPosition;
        console.log(`${riderName} stopped to refuel but lost his position, now he is ${changedPosition}.`);
      } else {
        console.log(`${riderName} does not need to stop for fuel!`);
      }
    }
    if (tokens[0] === 'Overtaking') {
      const riderName2 = tokens[2];
      const riderObj = riders.find(r => r.name === riderName);
      const riderObj2 = riders.find(r => r.name === riderName2);
      if (riderObj.pos < riderObj2.pos) {
        [riderObj.pos, riderObj2.pos] = [riderObj2.pos, riderObj.pos];
        console.log(`${riderName} overtook ${riderName2}!`);
      }
    }
    if (tokens[0] === 'EngineFail') {
      const lapsLeft = Number(tokens[2]);
      const index = riders.findIndex(r => r.name === riderName);
      riders.splice(index, 1);
      console.log(`${riderName} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
    }
  }
  for (const rider of riders) {
    console.log(`${rider.name}`);
    console.log(`  Final position: ${rider.pos}`);
  }
}
solve(["4",
  "Valentino Rossi|100|1",
  "Marc Marquez|90|3",
  "Jorge Lorenzo|80|4",
  "Johann Zarco|80|2",
  "StopForFuel - Johann Zarco - 90 - 5",
  "Overtaking - Marc Marquez - Jorge Lorenzo",
  "EngineFail - Marc Marquez - 10",
  "Finish"]
);