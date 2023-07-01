function PrintConvertJSONToObj(strJSON) {
    let obj = JSON.parse(strJSON);
    let entries = Object.entries(obj);
    for (let [property, value] of entries) {
        console.log(`${property}: ${value}`);
    }
}