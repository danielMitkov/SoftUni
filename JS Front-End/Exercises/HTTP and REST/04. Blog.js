function attachEvents() {
  let selectEl = document.querySelector(`#posts`);
  let posts;
  let btnLoad = document.querySelector(`#btnLoadPosts`);
  btnLoad.addEventListener(`click`, async () => {
    try {
      let response = await fetch(`http://localhost:3030/jsonstore/blog/posts`);
      posts = await response.json();
    } catch {
      return;
    }
    console.log(posts);
    for (let postId in posts) {
      let option = document.createElement(`option`);
      option.value = postId;
      option.textContent = posts[postId].title;
      selectEl.appendChild(option);
    }
  });
  let btnView = document.querySelector(`#btnViewPost`);
  btnView.addEventListener(`click`, async () => {
    let comments;
    try {
      let response = await fetch(`http://localhost:3030/jsonstore/blog/comments`);
      comments = await response.json();
    } catch {
      return;
    }
    console.log(comments);
    let h1 = document.querySelector(`#post-title`);
    let targetPost = posts[selectEl.value];
    console.log(targetPost);
    h1.textContent = targetPost.title;
    let p = document.querySelector(`#post-body`);
    p.textContent = targetPost.body;
    let ul = document.querySelector(`#post-comments`);
    ul.innerHTML = ``;
    for (let commentId in comments) {
      if (comments[commentId].postId !== selectEl.value) {
        continue;
      }
      let li = document.createElement(`li`);
      li.id = commentId;
      li.textContent = comments[commentId].text;
      ul.appendChild(li);
    }
  });
}

attachEvents();