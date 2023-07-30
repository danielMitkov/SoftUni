function attachEvents() {
  const url = 'http://localhost:3030/jsonstore/tasks/';
  const ul = document.querySelector('#todo-list');

  const titleEl = document.querySelector('#title');
  const addBtn = document.querySelector('#add-button');
  const loadBtn = document.querySelector('#load-button');

  loadBtn.addEventListener('click', async (event) => {
    event.preventDefault();
    ul.innerHTML = '';
    const responseLoad = await fetch(url);
    const answerLoad = await responseLoad.json();

    for (let obj of Object.values(answerLoad)) {

      const li = document.createElement('li');
      ul.appendChild(li);

      const span = document.createElement('span');
      span.textContent = obj.name;
      li.appendChild(span);

      const removeBtn = document.createElement('button');
      removeBtn.textContent = 'Remove';
      li.appendChild(removeBtn);

      removeBtn.addEventListener('click', async () => {
        await fetch(url + obj._id, { method: 'DELETE' });
        loadBtn.click();
      });
      const editBtn = document.createElement('button');
      editBtn.textContent = 'Edit';
      li.appendChild(editBtn);

      editBtn.addEventListener('click', async () => {
        span.remove();
        const input = document.createElement('input');
        input.value = span.textContent;
        li.prepend(input);

        editBtn.remove();
        const submitBtn = document.createElement('button');
        submitBtn.textContent = 'Submit';
        li.appendChild(submitBtn);

        submitBtn.addEventListener('click', async () => {
          await fetch(url + obj._id, {
            method: 'PATCH',
            body: JSON.stringify({ name: input.value })
          });
          loadBtn.click();
        });
      });
    }
  })
  addBtn.addEventListener('click', async (event) => {
    event.preventDefault();

    await fetch(url, {
      method: 'POST',
      body: JSON.stringify({ name: titleEl.value })
    });
    titleEl.value = '';
    loadBtn.click();
  });
}
attachEvents();