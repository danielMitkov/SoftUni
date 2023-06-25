function PrintHashTags(str) {
    for (let word of str.split(` `)) {
        if (/^#[a-zA-Z]+$/.test(word)) {
            console.log(word.slice(1));
        }
    }
}