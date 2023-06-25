function PrintPascalCaseSplit(str) {
    console.log(str.split(/(?=[A-Z])/).join(`, `));
}