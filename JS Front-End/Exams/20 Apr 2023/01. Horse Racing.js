function horseRacing(dataArr) {
  const [horsesStr, ...commandsArr] = dataArr;
  const horsesArr = horsesStr.split(`|`);
  for (let i = 0; i < commandsArr.length; ++i) {
    const commandStr = commandsArr[i];
    if (commandStr === `Finish`) {
      break;
    } else if (commandStr.startsWith(`Retake`)) {
      const [_, overtaking, overtaken] = commandStr.split(` `);
      const overtakingIndex = horsesArr.indexOf(overtaking);
      const overtakenIndex = horsesArr.indexOf(overtaken);
      if (overtakingIndex < overtakenIndex) {
        [horsesArr[overtakingIndex], horsesArr[overtakenIndex]] = [horsesArr[overtakenIndex], horsesArr[overtakingIndex]];
        console.log(`${overtaking} retakes ${overtaken}.`);
      }
    } else if (commandStr.startsWith(`Trouble`)) {
      const [_, horseStr] = commandStr.split(` `);
      const horseIndex = horsesArr.indexOf(horseStr);
      if (horseIndex > 0) {//if yes, it can drop
        [horsesArr[horseIndex], horsesArr[horseIndex - 1]] = [horsesArr[horseIndex - 1], horsesArr[horseIndex]];
        console.log(`Trouble for ${horseStr} - drops one position.`);
      }
    } else if (commandStr.startsWith(`Rage`)) {
      const [_, horseStr] = commandStr.split(` `);
      const horseIndex = horsesArr.indexOf(horseStr);
      let newIndex;
      if (horseIndex >= horsesArr.length - 3) {
        newIndex = horsesArr.length - 1;
      } else {
        newIndex = horseIndex + 2;
      }
      for (let j = horseIndex; j < newIndex; ++j) {
        [horsesArr[j], horsesArr[j + 1]] = [horsesArr[j + 1], horsesArr[j]];
      }
      console.log(`${horseStr} rages 2 positions ahead.`);
    } else if (commandStr.startsWith(`Miracle`)) {
      const horseStr = horsesArr[0];
      for (let k = 0; k < horsesArr.length - 1; ++k) {
        [horsesArr[k], horsesArr[k + 1]] = [horsesArr[k + 1], horsesArr[k]];
      }
      console.log(`What a miracle - ${horseStr} becomes first.`);
    }
  }
  console.log(horsesArr.join(`->`));
  console.log(`The winner is: ${horsesArr[horsesArr.length - 1]}`);
}