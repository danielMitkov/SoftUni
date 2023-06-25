function PrintSum(a, b) {
    let sum = 0;
    let numsStr = ``;
    for (let n = a; n <= b; ++n) {
        numsStr += n + ` `;
        sum += n;
    }
    console.log(`${numsStr.trimEnd()}\nSum: ${sum}`);
}