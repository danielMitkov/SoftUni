function PrintFlights(data) {
    let flightsStrArr = data[0];
    let statusesStrArr = data[1];
    let checkStatusStr = data[2][0];
    let dictCityFlight = {};//flight might change to cancelled
    for (let flightStr of flightsStrArr) {
        let [flight, ...cityArr] = flightStr.split(` `);
        let city = cityArr.join(` `);
        dictCityFlight[city] = flight;
    }
    for (let statusStr of statusesStrArr) {
        let [flight, status] = statusStr.split(` `);
        for (let cityKey in dictCityFlight) {
            if (dictCityFlight.hasOwnProperty(cityKey) && dictCityFlight[cityKey] === flight) {
                dictCityFlight[cityKey] = `Cancelled`;
            }
        }
    }
    if (checkStatusStr === `Cancelled`) {
        for (let cityKey in dictCityFlight) {
            if (dictCityFlight.hasOwnProperty(cityKey) && dictCityFlight[cityKey] === `Cancelled`) {
                console.log(`{ Destination: '${cityKey}', Status: 'Cancelled' }`);
            }
        }
    } else {
        for (let cityKey in dictCityFlight) {
            if (dictCityFlight.hasOwnProperty(cityKey) && dictCityFlight[cityKey] !== `Cancelled`) {
                console.log(`{ Destination: '${cityKey}', Status: 'Ready to fly' }`);
            }
        }
    }
}