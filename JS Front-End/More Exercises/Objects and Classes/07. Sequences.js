function printUniqueArrays(strArr) {
    let strSet = new Set();
    for (let str of strArr) {
        let numArr = JSON.parse(str).sort((a, b) => b - a);
        strSet.add(JSON.stringify(numArr));
    }
    let numArrArr = [...strSet].map(str => JSON.parse(str));
    numArrArr.sort((a, b) => a.length - b.length);
    for (let numArr of numArrArr) {
        console.log(`[${numArr.join(', ')}]`);
    }
}