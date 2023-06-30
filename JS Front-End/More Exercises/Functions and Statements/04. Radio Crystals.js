function PrintCuttingCrystals(ore) {
    for (let i = 1; i < ore.length; ++i) {
        function Calc(msg, check, operation) {
            let count = 0;
            while (check(ore[i])) {
                ore[i] = operation(ore[i]);
                count++;
            }
            if (count > 0) {
                console.log(`${msg} x${count}`);
                console.log(`Transporting and washing`);
                ore[i] = Math.floor(ore[i]);
            }
        }
        console.log(`Processing chunk ${ore[i]} microns`);
        Calc(`Cut`, n => n / 4 >= ore[0], n => n / 4);
        Calc(`Lap`, n => n - n * 0.2 >= ore[0], n => n - n * 0.2);
        Calc(`Grind`, n => n - 20 >= ore[0], n => n - 20);
        Calc(`Etch`, () => ore[i] - 2 >= ore[0] || ore[0] - (ore[i] - 2) === 1, n => n - 2);
        if (ore[i] + 1 === ore[0]) {
            ore[i]++;
            console.log(`X-ray x1`);
        }
        console.log(`Finished crystal ${ore[i]} microns`);
    }
}