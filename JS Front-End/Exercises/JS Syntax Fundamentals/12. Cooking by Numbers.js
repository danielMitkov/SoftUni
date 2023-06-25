function CookNumber(numStr, ...actions) {
    let num = Number(numStr);
    for (let act of actions) {
        switch (act) {
            case `chop`:
                num /= 2;
                break;
            case `dice`:
                num = Math.sqrt(num);
                break;
            case `spice`:
                num += 1;
                break;
            case `bake`:
                num *= 3;
                break;
            case `fillet`:
                num -= num * 0.2;
                break;
        }
        console.log(num);
    }
}