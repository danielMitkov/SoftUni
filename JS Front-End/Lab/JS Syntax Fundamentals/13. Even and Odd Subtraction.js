function EvenOddDiff(arr) {
    let evenSum = 0;
    let oddSum = 0;
    for (let i = 0; i < arr.length; ++i) {
        if (arr[i] % 2 === 0) {
            evenSum += arr[i];
            continue;
        }
        oddSum += arr[i];
    }
    console.log(`${evenSum - oddSum}`);
}