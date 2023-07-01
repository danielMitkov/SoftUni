function PrintObjLoop(obj) {
    let entries = Object.entries(obj);
    for (let [property, value] of entries) {
        console.log(`${property} -> ${value}`);
    }
}