function printCountOccurrences(dataStrArr) {
    let [keyWordsStr, ...words] = dataStrArr;
    let keyWords = keyWordsStr.split(` `);
    let dictionaryWordCount = {};
    for (let key of keyWords) {
        dictionaryWordCount[key] = 0;
        for (let word of words) {
            if (key === word) {
                dictionaryWordCount[key]++;
            }
        }
    }
    for (let [key, count] of Object.entries(dictionaryWordCount).sort((a, b) => b[1] - a[1])) {
        console.log(`${key} - ${count}`);
    }
}