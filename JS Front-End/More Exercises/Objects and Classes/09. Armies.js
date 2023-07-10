function printArmies(dataArr) {
    let leadersObj = {};
    for (let commandStr of dataArr) {
        if (commandStr.includes(`arrives`)) {
            let leaderStr = commandStr.replace(` arrives`, ``);
            leadersObj[leaderStr] = {};
        }
        else if (commandStr.includes(`:`)) {
            let [leaderStr, armyStr] = commandStr.split(`: `);
            let [armyNameStr, armyCountStr] = armyStr.split(`, `);
            if (leaderStr in leadersObj) {
                leadersObj[leaderStr][armyNameStr] = Number(armyCountStr);
            }
        }
        else if (commandStr.includes(`+`)) {
            let [armyNameStr, armyCountStr] = commandStr.split(` + `);
            for (let leaderStr in leadersObj) {
                for (let armyStr in leadersObj[leaderStr]) {
                    if (armyStr === armyNameStr) {
                        leadersObj[leaderStr][armyNameStr] += Number(armyCountStr);
                    }
                }
            }
        }
        else if (commandStr.includes(`defeated`)) {
            let leaderStr = commandStr.replace(` defeated`, ``);
            delete leadersObj[leaderStr];
        }
    }
    let leadersArr = Object.entries(leadersObj).sort((a, b) => {
        let sumA = 0;
        for (let [name, count] of Object.entries(a[1])) {
            sumA += count;
        }
        let sumB = 0;
        for (let [name, count] of Object.entries(b[1])) {
            sumB += count;
        }
        return sumB - sumA;
    });
    for (let [leaderStr, armiesObj] of leadersArr) {
        let armySumNum = 0;
        for (let armyNameStr in armiesObj) {
            armySumNum += armiesObj[armyNameStr]
        }
        console.log(`${leaderStr}: ${armySumNum}`);
        let leaderArmyArr = Object.entries(armiesObj);
        leaderArmyArr.sort((a, b) => b[1] - a[1]);
        for (let [armyNameStr, armyCountNum] of leaderArmyArr) {
            console.log(`>>> ${armyNameStr} - ${armyCountNum}`);
        }
    }
}
// printArmies([
//     'Rick Burr arrives',
//     'Findlay arrives',
//     'Rick Burr: Juard, 1500',
//     'Wexamp arrives',
//     'Findlay: Wexamp, 34540',
//     'Wexamp + 340',
//     'Wexamp: Britox, 1155',
//     'Wexamp: Juard, 43423'
// ]);