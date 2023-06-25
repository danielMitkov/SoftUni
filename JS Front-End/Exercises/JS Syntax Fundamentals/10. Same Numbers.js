function AreDigitsSame(num) {
    const digits = num.toString().split(``).map(Number);
    const areSame = new Set(digits).size === 1;
    const sum = digits.reduce((total, current) => total + current);
    console.log(areSame);
    console.log(sum);
}