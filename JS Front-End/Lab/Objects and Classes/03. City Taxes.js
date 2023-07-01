function GetCityTaxesObj(name, population, treasury) {
    let obj = {
        name: name,
        population: population,
        treasury: treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percent) {
            this.population += this.population * (percent / 100);
        },
        applyRecession(percent) {
            this.treasury -= this.treasury * (percent / 100);
        }
    };
    return obj;
}