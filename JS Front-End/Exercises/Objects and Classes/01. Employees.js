function PrintEmployees(data) {
    for (let str of data) {
        let obj = {
            name: str,
            num: str.length
        };
        console.log(`Name: ${str} -- Personal Number: ${obj.num}`);
    }
}