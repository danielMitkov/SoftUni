function printCatalogue(data) {
    let catalogue = {};
    for (let strItem of data) {
        let [name, cost] = strItem.split(` : `);
        let char = name[0];
        if (!(char in catalogue)) {
            catalogue[char] = {};
        }
        catalogue[char][name] = cost;
    }
    let sortedChars = Object.entries(catalogue)
        .sort((a, b) => a[0].localeCompare(b[0]));

    for (let [char, dictProducts] of sortedChars) {

        console.log(char);

        let sortedProducts = Object.entries(dictProducts)
            .sort((a, b) => a[0].localeCompare(b[0]));

        for (let [name, cost] of sortedProducts) {
            console.log(`  ${name}: ${cost}`);
        }
    }
}