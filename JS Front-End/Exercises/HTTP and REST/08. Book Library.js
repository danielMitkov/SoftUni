function attachEvents() {
  const formText = document.querySelector(`#form h3`);
  const fieldTitle = document.querySelector(`#form input[name="title"]`);
  const fieldAuthor = document.querySelector(`#form input[name="author"]`);
  let bookId = null;
  const btnLoad = document.querySelector(`#loadBooks`);
  const btnSubmit = document.querySelector(`#form button`);
  btnSubmit.addEventListener(`click`, async () => {
    if (fieldTitle.value === `` || fieldAuthor.value === ``) { return; }
    let url = `http://localhost:3030/jsonstore/collections/books`;
    let method = `POST`;
    if (bookId) {
      url += `/` + bookId;
      method = `PUT`;
      bookId = null;
      formText.textContent = `FORM`;
      btnSubmit.textContent = `Submit`;
    }
    await fetch(url, {
      method: method, body: JSON.stringify({ author: fieldAuthor.value, title: fieldTitle.value })
    });
    btnLoad.click();
  });
  const tbody = document.querySelector(`tbody`);
  btnLoad.addEventListener(`click`, async () => {
    const responseLoad = await fetch(`http://localhost:3030/jsonstore/collections/books`);
    const books = await responseLoad.json();
    tbody.innerHTML = ``;
    for (let id in books) {
      const tr = document.createElement('tr');
      tr.innerHTML = `
      <td>${books[id].title}</td>
      <td>${books[id].author}</td>
      <td>
        <button class="edit-btn">Edit</button>
        <button class="delete-btn">Delete</button>
      </td>`;
      tbody.appendChild(tr);
      const btnEdit = tr.querySelector(`.edit-btn`);
      btnEdit.addEventListener(`click`, () => {
        formText.textContent = `Edit FORM`;
        btnSubmit.textContent = `Save`;
        bookId = id;
        fieldTitle.value = books[id].title;
        fieldAuthor.value = books[id].author;
      });
      const btnDel = tr.querySelector(`.delete-btn`);
      btnDel.addEventListener(`click`, async () => {
        await fetch(`http://localhost:3030/jsonstore/collections/books/${id}`, { method: `DELETE` });
        formText.textContent = `FORM`;
        btnSubmit.textContent = `Submit`;
        btnLoad.click();
      });
    }
  });
}
attachEvents();