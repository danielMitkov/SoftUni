class Storage {
    storage = [];

    constructor(capacity) {
        this.capacity = capacity;
    }

    get totalCost() {
        let cost = 0;
        for (let product of this.storage) {
            cost += product.price * product.quantity;
        }
        return cost;
    }

    addProduct(productObj) {
        this.storage.push(productObj);
        this.capacity -= productObj.quantity;
    }

    getProducts() {
        return this.storage.map(x => JSON.stringify(x)).join('\n');
    }
}