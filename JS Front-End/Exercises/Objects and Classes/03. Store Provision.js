function PrintInventory(stock, ordered) {
    let items = [...stock, ...ordered];
    let dictionaryNameCount = {};
    for (let i = 0; i < items.length; i += 2) {
        let name = items[i];
        let count = Number(items[i + 1]);
        if (name in dictionaryNameCount) {
            dictionaryNameCount[name] += count;
        } else {
            dictionaryNameCount[name] = count;
        }
    }
    for (let name in dictionaryNameCount) {
        console.log(`${name} -> ${dictionaryNameCount[name]}`);
    }
}