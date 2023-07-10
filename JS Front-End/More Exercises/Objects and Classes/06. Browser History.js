function PrintBrowserState(browserObj, actionStrArr) {
    for (let actionStr of actionStrArr) {
        let [commandStr, ...siteStrArr] = actionStr.split(` `);
        let siteStr = siteStrArr.join(` `);
        if (commandStr === `Open`) {
            browserObj["Open Tabs"].push(siteStr);
            browserObj["Browser Logs"].push(actionStr);
        }
        else if (commandStr === `Close`) {
            let i = browserObj["Open Tabs"].indexOf(siteStr);
            if (i > -1) {
                browserObj["Open Tabs"].splice(i, 1);
                browserObj["Recently Closed"].push(siteStr);
                browserObj["Browser Logs"].push(actionStr);
            }
        }
        else {//for clear logs
            browserObj["Open Tabs"] = [];
            browserObj["Recently Closed"] = [];
            browserObj["Browser Logs"] = [];
        }
    }
    console.log(browserObj["Browser Name"]);
    console.log(`Open Tabs: ${browserObj["Open Tabs"].join(`, `)}`);
    console.log(`Recently Closed: ${browserObj["Recently Closed"].join(`, `)}`);
    console.log(`Browser Logs: ${browserObj["Browser Logs"].join(`, `)}`);
}