function SplitReverse(n, arr) {
    let subArr = arr.slice(0, n);
    subArr.reverse();
    console.log(`${subArr.join(` `)}`);
}