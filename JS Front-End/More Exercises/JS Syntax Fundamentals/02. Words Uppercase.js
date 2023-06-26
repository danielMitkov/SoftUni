function PrintWordsUpperCase(str) {
    const words = str.split(/\W+/).filter(x => x !== ``).map(el => el.toUpperCase());
    console.log(words.join(`, `));
}