function PrintParkingCarNumbers(data) {
    let carNumsSet = new Set();
    for (let str of data) {
        let [direction, carNum] = str.split(`, `);
        if (direction === `IN`) {
            carNumsSet.add(carNum);
        }
        if (direction === `OUT`) {
            carNumsSet.delete(carNum);
        }
    }
    if (carNumsSet.size === 0) {
        console.log(`Parking Lot is Empty`);
        return;
    }
    let sortedArr = [...carNumsSet].sort();
    console.log(sortedArr.join(`\n`));
}