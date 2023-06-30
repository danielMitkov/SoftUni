function PrintDNA(rows) {
    let strings = [`**,.**`, `*,--.*`, `,----.`, `*,--.*`];
    let chars = [...`ATCGTTAGGG`];
    let strIndex = -1;
    let charIndex = 0;
    for (let n = 1; n <= rows; ++n) {
        strIndex++;
        if (strIndex === strings.length) {
            strIndex = 0;
        }
        let str = strings[strIndex];
        str = str.replace(`,`, chars[charIndex]);
        charIndex++;
        if (charIndex === chars.length) {
            charIndex = 0;
        }
        str = str.replace(`.`, chars[charIndex]);
        charIndex++;
        if (charIndex === chars.length) {
            charIndex = 0;
        }
        console.log(str);
    }
}