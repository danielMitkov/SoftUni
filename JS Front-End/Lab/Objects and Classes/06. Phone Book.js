function PrintPhoneBook(arr) {
    let phonebook = {};
    for (let line of arr) {
        let tokens = line.split(` `);
        let name = tokens[0];
        let num = tokens[1];
        phonebook[name] = num;
    }
    for (let key in phonebook) {
        console.log(`${key} -> ${phonebook[key]}`);
    }
}