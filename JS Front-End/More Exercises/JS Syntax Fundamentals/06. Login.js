function PrintArrLogin(passwords) {
    const [key, ...passes] = passwords;
    for (let i = 0; i < passes.length && i < 4; ++i) {
        if (key === [...passes[i]].reverse().join(``)) {
            console.log(`User ${key} logged in.`);
            return;
        }
        if (i === 3) {
            console.log(`User ${key} blocked!`);
            return;
        }
        console.log(`Incorrect password. Try again.`);
    }
}