function PrintCalcSpiceMinedDays(yield) {
    let days = 0;
    let spice = 0;
    while (yield >= 100) {
        spice += yield - 26;
        yield -= 10;
        days++;
    }
    spice -= 26;
    if (spice < 0) {
        spice = 0;
    }
    console.log(days);
    console.log(spice);
}