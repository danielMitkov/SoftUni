function CountTextMatches(text, word) {
    const wordsArr = text.split(` `);
    let count = 0;
    for (let w of wordsArr) {
        if (w === word) {
            count++;
        }
    }
    console.log(count);
}