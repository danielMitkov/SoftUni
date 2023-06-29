function PrintNxNMatrix(n) {
    const line = Array(n).fill(n);
    for (let row = 1; row <= n; ++row) {
        console.log(line.join(` `));
    }
}