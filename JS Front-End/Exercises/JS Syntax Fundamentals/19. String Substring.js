function PrintMatch(key, text) {
    keyLower = key.toLowerCase();
    for (const wordLower of text.toLowerCase().split(` `)) {
        if (keyLower === wordLower) {
            console.log(key);
            return;
        }
    }
    console.log(`${key} not found!`);
}