function CalcCircleArea(r) {
    if (typeof r === `number`) {
        console.log(`${(Math.PI * r * r).toFixed(2)}`);
        return;
    }
    console.log(`We can not calculate the circle area, because we receive a ${typeof r}.`);
}