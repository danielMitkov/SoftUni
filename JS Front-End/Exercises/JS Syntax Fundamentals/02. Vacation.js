function GetPrice(count, type, day) {
    const prices = {
        Students: {
            Friday: 8.45,
            Saturday: 9.8,
            Sunday: 10.46
        },
        Business: {
            Friday: 10.9,
            Saturday: 15.6,
            Sunday: 16
        },
        Regular: {
            Friday: 15,
            Saturday: 20,
            Sunday: 22.5
        }
    };
    if (type === `Business` && count >= 100) {
        count -= 10;
    }
    const cost = prices[type][day];
    let total = cost * count;
    if (type === `Students` && count >= 30) {
        total -= total * 0.15;
    }
    if (type === `Regular` && count >= 10 && count <= 20) {
        total -= total * 0.05;
    }
    console.log(`Total price: ${total.toFixed(2)}`);
}