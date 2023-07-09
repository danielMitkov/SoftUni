function PrintMovies(strArr) {
    let movieObjects = [{ name: `Inception` }];
    for (let str of strArr) {
        if (str.includes(`addMovie`)) {
            let movieName = str.split(`addMovie `)[1];
            movieObjects.push({ name: movieName });
        } else if (str.includes(`directedBy`)) {
            let [movieName, director] = str.split(` directedBy `);
            let movie = movieObjects.find(obj => obj.name === movieName);
            if (movie !== undefined) {
                movie.director = director;
            }
        } else if (str.includes(`onDate`)) {
            let [movieName, date] = str.split(` onDate `);
            let movie = movieObjects.find(obj => obj.name === movieName);
            if (movie !== undefined) {
                movie.date = date;
            }
        }
    }
    movieObjects = movieObjects.filter(obj => Object.keys(obj).length === 3);
    for (let movieObj of movieObjects) {
        console.log(JSON.stringify(movieObj));
    }
}