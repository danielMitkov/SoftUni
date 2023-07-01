function PrintSortedObj(data) {
    let obj = {};
    for (let str of data) {
        let [name, address] = str.split(`:`);
        obj[name] = address;
    }
    let entries = Object.entries(obj);
    entries.sort((a, b) => a[0].localeCompare(b[0]));
    for (let [name, address] of entries) {
        console.log(`${name} -> ${address}`);
    }
}