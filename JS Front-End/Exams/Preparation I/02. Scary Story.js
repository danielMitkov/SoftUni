function solve() {
  const firstNameEl = document.querySelector('#first-name');
  const lastNameEl = document.querySelector('#last-name');
  const ageEl = document.querySelector('#age');
  const titleEl = document.querySelector('#story-title');
  const genreEl = document.querySelector('#genre');
  const storyEl = document.querySelector('#story');
  const publishBtn = document.querySelector('#form-btn');
  const ul = document.querySelector('ul');
  publishBtn.addEventListener('click', (event) => {
    event.preventDefault();
    if (firstNameEl.value === '' || lastNameEl.value === '' || ageEl.value === '' || titleEl.value === '' || storyEl.value === '') {
      return;
    }
    const li = document.createElement('li');
    li.classList.add('story-info');
    ul.appendChild(li);

    const article = document.createElement('article');
    li.appendChild(article);

    const firstName = firstNameEl.value;
    const lastName = lastNameEl.value;
    const age = ageEl.value;
    const title = titleEl.value;
    const genre = genreEl.value;
    const story = storyEl.value;

    const h4 = document.createElement('h4');
    h4.textContent = `Name: ${firstName} ${lastName}`;
    article.appendChild(h4);

    const pAge = document.createElement('p');
    pAge.textContent = 'Age: ' + age;
    article.appendChild(pAge);

    const pTitle = document.createElement('p');
    pTitle.textContent = 'Title: ' + title;
    article.appendChild(pTitle);

    const pGenre = document.createElement('p');
    pGenre.textContent = 'Genre: ' + genre;
    article.appendChild(pGenre);

    const pStory = document.createElement('p');
    pStory.textContent = story
    article.appendChild(pStory);

    const saveBtn = document.createElement('button');
    saveBtn.classList.add('save-btn');
    saveBtn.textContent = 'Save Story';
    li.appendChild(saveBtn);
    saveBtn.addEventListener('click', () => {
      const main = document.querySelector('#main');
      main.innerHTML = '';
      const h1 = document.createElement('h1');
      h1.textContent = 'Your scary story is saved!';
      main.appendChild(h1);
    });
    const editBtn = document.createElement('button');
    editBtn.classList.add('edit-btn');
    editBtn.textContent = 'Edit Story';
    li.appendChild(editBtn);
    editBtn.addEventListener('click', () => {
      firstNameEl.value = firstName;
      lastNameEl.value = lastName;
      ageEl.value = age;
      titleEl.value = title;
      genreEl.value = genre;
      storyEl.value = story;
      li.remove();
      publishBtn.disabled = false;
    });
    const deleteBtn = document.createElement('button');
    deleteBtn.classList.add('delete-btn');
    deleteBtn.textContent = 'Delete Story';
    li.appendChild(deleteBtn);
    deleteBtn.addEventListener('click', () => {
      li.remove();
      publishBtn.disabled = false;
    });
    firstNameEl.value = '';
    lastNameEl.value = '';
    ageEl.value = '';
    titleEl.value = '';
    genreEl.value = 'Disturbing';
    storyEl.value = '';
    publishBtn.disabled = true;
  });
}