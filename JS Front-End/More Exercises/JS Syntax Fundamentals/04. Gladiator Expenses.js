function PrintGladiatorExpenses(loses, helmetCost, swordCost, shieldCost, armorCost) {
    let breaksHelmet = 0;
    let breaksSword = 0;
    let breaksShield = 0;
    let breaksShieldCounter = 0;
    let breaksArmor = 0;
    for (let day = 1; day <= loses; ++day) {
        if (day % 2 === 0) {
            breaksHelmet++;
        }
        if (day % 3 === 0) {
            breaksSword++;
        }
        if (day % 2 === 0 && day % 3 === 0) {
            breaksShield++;
            breaksShieldCounter++;
        }
        if (breaksShieldCounter == 2) {
            breaksArmor++;
            breaksShieldCounter = 0;
        }
    }
    const cost = breaksHelmet * helmetCost + breaksSword * swordCost + breaksShield * shieldCost + breaksArmor * armorCost;
    console.log(`Gladiator expenses: ${cost.toFixed(2)} aureus`);
}