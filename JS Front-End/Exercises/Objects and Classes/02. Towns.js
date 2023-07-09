function PrintTownCoordsObjects(townDataStrArr) {
    for (let dataStr of townDataStrArr) {
        let [town, latitude, longitude] = dataStr.split(` | `);
        let townObj = {
            town,
            latitude: parseFloat(latitude).toFixed(2),
            longitude: parseFloat(longitude).toFixed(2)
        };
        console.log(townObj);
    }
}