function PrintCarWash(actions) {
    let cleanness = 0;
    for (let command of actions) {
        switch (command) {
            case `soap`:
                cleanness += 10;
                break;
            case `water`:
                cleanness += cleanness * 0.2;
                break;
            case `vacuum cleaner`:
                cleanness += cleanness * 0.25;
                break;
            case `mud`:
                cleanness -= cleanness * 0.1;
                break;
        }
    }
    console.log(`The car is ${cleanness.toFixed(2)}% clean.`);
}