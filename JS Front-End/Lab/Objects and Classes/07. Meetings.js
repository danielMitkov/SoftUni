function PrintMeetingsConflicts(arr) {
    let meetings = {};
    for (let line of arr) {
        let [day, name] = line.split(` `);
        if (meetings.hasOwnProperty(day)) {
            console.log(`Conflict on ${day}!`);
            continue;
        }
        meetings[day] = name;
        console.log(`Scheduled for ${day}`);
    }
    for (let key in meetings) {
        console.log(`${key} -> ${meetings[key]}`);
    }
}