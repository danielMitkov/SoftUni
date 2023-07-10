function organizeBooks(input) {
    const shelves = {};

    for (const line of input) {
        if (line.includes("->")) {
            const [shelfId, shelfGenre] = line.split(" -> ");
            if (!(shelfId in shelves)) {
                shelves[shelfId] = { genre: shelfGenre, books: [] };
            }
        } else {
            const [bookInfo, bookGenre] = line.split(", ");
            const [bookTitle, bookAuthor] = bookInfo.split(": ");
            const shelf = Object.values(shelves).find(
                (shelf) => shelf.genre === bookGenre
            );
            if (shelf) {
                shelf.books.push({ title: bookTitle, author: bookAuthor });
            }
        }
    }

    const sortedShelves = Object.entries(shelves).sort(
        (a, b) => b[1].books.length - a[1].books.length
    );

    for (const [shelfId, shelf] of sortedShelves) {
        shelf.books.sort((a, b) => a.title.localeCompare(b.title));
        console.log(`${shelfId} ${shelf.genre}: ${shelf.books.length}`);
        for (const book of shelf.books) {
            console.log(`--> ${book.title}: ${book.author}`);
        }
    }
}
organizeBooks(['1 -> mystery', '2 -> sci-fi',
    'Child of Silver: Bruce Rich, mystery',
    'Lions and Rats: Gabe Roads, history',
    'Effect of the Void: Shay B, romance',
    'Losing Dreams: Gail Starr, sci-fi',
    'Name of Earth: Jo Bell, sci-fi']
);