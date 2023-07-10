function printUserCommentsInfo(strArr) {
  let usersArr = [];
  let articlesArr = [];
  let articlesObj = {};
  for (let str of strArr) {
    if (str.startsWith(`user `)) {
      let name = str.split(`user `)[1];
      if (usersArr.includes(name) === false) {
        usersArr.push(name);
      }
    }
    if (str.startsWith(`article `)) {
      let article = str.split(`article `)[1];
      if (articlesArr.includes(article) === false) {
        articlesArr.push(article);
      }
    }
    if (str.includes(` posts on `)) {
      let [postStr, contentStr] = str.split(`: `);
      let [name, article] = postStr.split(` posts on `);
      let comment = contentStr.replace(`, `, ` - `);
      if (usersArr.includes(name) === false) {
        continue;
      }
      if (articlesArr.includes(article) === false) {
        continue;
      }
      if ((article in articlesObj) === false) {
        articlesObj[article] = {};
      }
      if ((name in articlesObj[article]) === false) {
        articlesObj[article][name] = comment;
      }
    }
  }
  let articlesEntries = Object.entries(articlesObj);
  articlesEntries.sort((a, b) => {
    let dictA = a[1];
    let dictB = b[1];
    return Object.keys(dictB).length - Object.keys(dictA).length;
  });
  for (let [article, dict] of articlesEntries) {
    console.log(`Comments on ${article}`);
    let dictEntries = Object.entries(dict).sort((a, b) => {
      let nameA = a[0];
      let nameB = b[0];
      return nameA.localeCompare(nameB);
    });
    for (let [name, comment] of dictEntries) {
      console.log(`--- From user ${name}: ${comment}`);
    }
  }
}
printUserCommentsInfo([
  'user aUser123',
  'someUser posts on someArticle: NoTitle, stupidComment',
  'article Books',
  'article Movies',
  'article Shopping',
  'user someUser',
  'user uSeR4',
  'user lastUser',
  'uSeR4 posts on Books: I like books, I do really like them',
  'uSeR4 posts on Movies: I also like movies, I really do',
  'someUser posts on Shopping: title, I go shopping every day',
  'someUser posts on Movies: Like, I also like movies very much'
]);