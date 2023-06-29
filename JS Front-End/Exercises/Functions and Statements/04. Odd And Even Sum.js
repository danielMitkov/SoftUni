function PrintSumNumEvenOdd(num) {
    let sumEven = 0;
    let sumOdd = 0;
    for (let char of String(num)) {
        let n = Number(char);
        if (n % 2 === 0) {
            sumEven += n;
        } else {
            sumOdd += n;
        }
    }
    console.log(`Odd sum = ${sumOdd}, Even sum = ${sumEven}`);
}