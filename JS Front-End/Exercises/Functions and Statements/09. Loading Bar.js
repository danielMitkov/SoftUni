function PrintLoadingBar(percent) {
    const percentSigns = `%`.repeat(percent / 10);
    const dots = `.`.repeat((100 - percent) / 10);
    if (percent < 100) {
        console.log(`${percent}% [${percentSigns}${dots}]`);
        console.log(`Still loading...`);
        return;
    }
    console.log(`100% Complete!`);
    console.log(`[%%%%%%%%%%]`);
}