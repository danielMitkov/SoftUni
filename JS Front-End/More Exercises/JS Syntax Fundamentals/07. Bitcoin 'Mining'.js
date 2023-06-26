function PrintBuyingBitcoins(goldGramsArr) {
    const goldToLv = 67.51;
    const bitcoinPriceLv = 11949.16;
    let lv = 0;
    let firstBitcoinDay = -1;
    let bitcoinsBought = 0;
    for (let i = 0; i < goldGramsArr.length; ++i) {
        const day = i + 1;
        if (day % 3 === 0) {
            goldGramsArr[i] -= goldGramsArr[i] * 0.3;
        }
        lv += goldGramsArr[i] * goldToLv;
        while (lv >= bitcoinPriceLv) {
            lv -= bitcoinPriceLv;
            bitcoinsBought++;
            if (firstBitcoinDay === -1) {
                firstBitcoinDay = day;
            }
        }
    }
    console.log(`Bought bitcoins: ${bitcoinsBought}`);
    if (firstBitcoinDay !== -1) {
        console.log(`Day of the first purchased bitcoin: ${firstBitcoinDay}`);
    }
    console.log(`Left money: ${lv.toFixed(2)} lv.`);
}