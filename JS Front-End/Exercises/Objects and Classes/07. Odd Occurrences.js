function PrintOddWordOccurrences(sentence) {
    let wordsArr = sentence.toLowerCase().split(` `);
    let dictWordCount = [];
    for (let word of wordsArr) {
        let storedWord = dictWordCount.find(el => el[0] === word);
        if (storedWord !== undefined) {
            storedWord[1]++;
        } else {
            dictWordCount.push([word, 1]);
        }
    }
    let filteredDict = dictWordCount.filter(([word, count]) => count % 2 !== 0);
    let resultWords = filteredDict.map(kvp => kvp[0]);
    console.log(resultWords.join(` `));
}