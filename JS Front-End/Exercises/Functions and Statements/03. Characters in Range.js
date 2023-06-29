function PrintASCIIRange(char1, char2) {
    const start = Math.min(char1.charCodeAt(0), char2.charCodeAt(0));
    const end = Math.max(char1.charCodeAt(0), char2.charCodeAt(0));
    const chars = [];
    for (let i = start + 1; i < end; i++) {
        chars.push(String.fromCharCode(i));
    }
    console.log(chars.join(` `));
}