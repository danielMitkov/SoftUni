function RevealWords(wordsStr, text) {
    const wordsArr = wordsStr.split(`, `);
    for (let wordStr of wordsArr) {
        text = text.replace(`*`.repeat(wordStr.length), wordStr);
    }
    console.log(text);
}