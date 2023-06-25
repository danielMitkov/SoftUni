function RotateArr(arr, rotationsCount) {
    for (let n = rotationsCount; n > 0; --n) {
        const firstElement = arr.shift();
        arr.push(firstElement);
    }
    console.log(arr.join(` `));
}