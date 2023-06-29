function PrintFactorialDivision(a, b) {
    function GetFactorial(num) {
        let result = 1;
        for (let n = 1; n <= num; ++n) {
            result *= n;
        }
        return result;
    }
    const facA = GetFactorial(a);
    const facB = GetFactorial(b);
    console.log((facA / facB).toFixed(2));
}