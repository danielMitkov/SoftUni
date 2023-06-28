function PrintResultSign(a, b, c) {
    const minuses = `${a}${b}${c}`.match(/-/g);
    const sign = minuses !== null && minuses.length % 2 !== 0 ? `Negative` : `Positive`;
    console.log(sign);
}