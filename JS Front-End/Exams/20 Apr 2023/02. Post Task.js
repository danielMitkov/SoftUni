window.addEventListener("load", solve);

function solve() {
  const publishBtn = document.querySelector(`#publish-btn`);
  publishBtn.addEventListener(`click`, () => {
    const titleField = document.querySelector(`#task-title`);
    const categoryField = document.querySelector(`#task-category`);
    const contentField = document.querySelector(`#task-content`);
    if (titleField.value === `` || categoryField.value === `` || contentField.value === ``) {
      return;
    }
    const postLi = document.createElement(`li`);
    postLi.classList.add(`rpost`);
    postLi.innerHTML = `
    <article>
      <h4>${titleField.value}</h4>
      <p>Category: ${categoryField.value}</p>
      <p>Content: ${contentField.value}</p>
    </article>
    <button class="action-btn edit">Edit</button>
    <button class="action-btn post">Post</button>`;
    const reviewUl = document.querySelector(`#review-list`);
    reviewUl.appendChild(postLi);
    titleField.value = ``;
    categoryField.value = ``;
    contentField.value = ``;
    const editBtn = postLi.querySelector(`.edit`);
    editBtn.addEventListener(`click`, () => {
      const h4title = postLi.querySelector(`h4`);
      const pCategory = postLi.querySelector(`p`);
      const pContent = postLi.querySelectorAll(`p`)[1];
      titleField.value = h4title.textContent;
      categoryField.value = pCategory.textContent.replace(`Category: `, ``);
      contentField.value = pContent.textContent.replace(`Content: `, ``);
      postLi.remove();
    });
    const postBtn = postLi.querySelector(`.post`);
    postBtn.addEventListener(`click`, () => {
      const ulPublished = document.querySelector(`#published-list`);
      ulPublished.appendChild(postLi);
      editBtn.remove();
      postBtn.remove();
    });
  });
}