function PrintBasicCalc(a, action, b) {
    switch (action) {
        case `+`:
            console.log((a + b).toFixed(2));
            break;
        case `-`:
            console.log((a - b).toFixed(2));
            break;
        case `*`:
            console.log((a * b).toFixed(2));
            break;
        case `/`:
            console.log((a / b).toFixed(2));
            break;
    }
}