function PrintHeroesInfo(dataStrArr) {
    let heroes = [];
    for (let str of dataStrArr) {
        let [name, level, itemsStr] = str.split(` / `);
        let [...items] = itemsStr.split(`, `);
        heroes.push({ name, level, items });
    }
    heroes.sort((a, b) => a.level - b.level);
    for (let { name, level, items } of heroes) {
        console.log(`Hero: ${name}`);
        console.log(`level => ${level}`);
        console.log(`items => ${items.join(`, `)}`);
    }
}