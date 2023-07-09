function PrintJSONDictionary(data) {
    let dict = {};
    for (let str of data) {
        let obj = JSON.parse(str);
        dict = { ...dict, ...obj };
    }
    for (let kvp of Object.entries(dict).sort()) {
        console.log(`Term: ${kvp[0]} => Definition: ${kvp[1]}`);
    }
}