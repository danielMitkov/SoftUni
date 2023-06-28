function PrintItemPrice(item, count) {
    switch (item) {
        case `coffee`:
            console.log((count * 1.5).toFixed(2));
            break;
        case `water`:
            console.log((count * 1).toFixed(2));
            break;
        case `coke`:
            console.log((count * 1.4).toFixed(2));
            break;
        case `snacks`:
            console.log((count * 2).toFixed(2));
            break;
    }
}