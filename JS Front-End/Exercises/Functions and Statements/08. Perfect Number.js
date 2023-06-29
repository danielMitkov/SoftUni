function PrintIsNumPerfect(num) {
    let sum = 0;
    for (let n = 1; n < num; ++n) {
        if (num % n === 0) {
            sum += n;
        }
    }
    console.log(sum === num ? `We have a perfect number!` : `It's not so perfect.`);
}