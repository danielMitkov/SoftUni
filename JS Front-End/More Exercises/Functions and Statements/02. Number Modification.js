function PrintAppendingAverage(num) {
    function GetAverage(digits) {
        let sum = 0;
        digits.forEach((num) => sum += num);
        return sum / digits.length;
    }
    let digits = [...String(num)].map(Number);
    while (GetAverage(digits) <= 5) {
        digits.push(9);
    }
    console.log(digits.join(``));
}