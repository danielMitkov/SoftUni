function printGarageCars(carsStrArr) {
    let garagesObj = {};
    for (let carStr of carsStrArr) {
        let [garageNumStr, carObjStr] = carStr.split(` - `);
        carObjStr = carObjStr.split(`: `).join(` - `);//replace
        if (!(garageNumStr in garagesObj)) {
            garagesObj[garageNumStr] = [];
        }
        garagesObj[garageNumStr].push(carObjStr);
    }
    for (let garageNumStr in garagesObj) {
        console.log(`Garage № ${garageNumStr}`);
        for (let carStr of garagesObj[garageNumStr]) {
            console.log(`--- ${carStr}`);
        }
    }
}