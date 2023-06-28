function PrintSimpleCalc(a, b, operation) {
    const prices = {
        'add': a + b,
        'subtract': a - b,
        'multiply': a * b,
        'divide': a / b
    }
    console.log(prices[operation]);
}