function PrintSongs(data) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }
    let songs = [];
    for (let i = 1; i < data.length - 1; ++i) {
        let [typeList, name, time] = data[i].split(`_`);
        songs.push(new Song(typeList, name, time));
    }
    let typeList = data[data.length - 1];
    if (typeList === `all`) {
        for (let song of songs) {
            console.log(song.name);
        }
        return;
    }
    for (let song of songs) {
        if (song.typeList === typeList) {
            console.log(song.name);
        }
    }
}
PrintSongs(
    [2,
        'like_Replay_3:15',
        'ban_Photoshop_3:48',
        'all']

);