function PrintAreDistancesIntegers(points) {
    let x1 = points[0];
    let y1 = points[1];
    let x2 = points[2];
    let y2 = points[3];
    function CalcDistance(x1, y1, x2, y2) {
        return Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);
    }
    function PrintValidity(x1, y1, x2, y2) {
        const distance = CalcDistance(x1, y1, x2, y2);
        const validMsg = Number.isInteger(distance) ? `valid` : `invalid`;
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${validMsg}`);
    }
    PrintValidity(x1, y1, 0, 0);
    PrintValidity(x2, y2, 0, 0);
    PrintValidity(x1, y1, x2, y2);
}