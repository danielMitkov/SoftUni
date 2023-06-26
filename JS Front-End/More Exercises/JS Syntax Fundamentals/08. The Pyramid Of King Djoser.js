function PrintCalcPyramidResources(base, rowHeight) {
    let stones = 0;
    let marbles = 0;
    let lapises = 0;
    let lapisCounter = 0;
    let gold = 0;
    let height = 0;
    for (let rowSize = base; rowSize >= 1; rowSize -= 2) {
        height += 1 * rowHeight;
        const area = rowSize * rowSize * rowHeight;
        if ((base % 2 === 0 && rowSize === 2) || (base % 1 === 0 && rowSize === 1)) {
            gold += area;
            break;
        }
        lapisCounter++;
        const currentStones = (rowSize - 2) * (rowSize - 2) * rowHeight;
        stones += currentStones;
        const decoration = area - currentStones;
        if (lapisCounter === 5) {
            lapises += decoration;
            lapisCounter = 0;
        } else {
            marbles += decoration;
        }
    }
    console.log(`Stone required: ${Math.ceil(stones)}`);
    console.log(`Marble required: ${Math.ceil(marbles)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapises)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(height)}`);
}