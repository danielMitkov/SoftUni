window.addEventListener('load', solve);

function solve() {
  const addBtn = document.getElementById('add-btn');
  const allHitsContainer = document.querySelector('.all-hits-container');
  const savedContainer = document.querySelector('.saved-container');
  const totalLikes = document.querySelector('#total-likes p');

  addBtn.addEventListener('click', function (event) {
    event.preventDefault();
    const genreInput = document.getElementById('genre');
    const nameInput = document.getElementById('name');
    const authorInput = document.getElementById('author');
    const dateInput = document.getElementById('date');

    const genreValue = genreInput.value;
    const nameValue = nameInput.value;
    const authorValue = authorInput.value;
    const dateValue = dateInput.value;

    if (
      genreValue.trim() === '' ||
      nameValue.trim() === '' ||
      authorValue.trim() === '' ||
      dateValue.trim() === ''
    ) {
      return;
    }

    const hitsInfoDiv = document.createElement('div');
    hitsInfoDiv.classList.add('hits-info');

    const img = document.createElement('img');
    img.src = './static/img/img.png';

    const genreHeading = document.createElement('h2');
    genreHeading.textContent = `Genre: ${genreValue}`;

    const nameHeading = document.createElement('h2');
    nameHeading.textContent = `Name: ${nameValue}`;

    const authorHeading = document.createElement('h2');
    authorHeading.textContent = `Author: ${authorValue}`;

    const dateHeading = document.createElement('h3');
    dateHeading.textContent = `Date: ${dateValue}`;

    const saveButton = document.createElement('button');
    saveButton.classList.add('save-btn');
    saveButton.textContent = 'Save song';


    const likeButton = document.createElement('button');
    likeButton.classList.add('like-btn');
    likeButton.textContent = 'Like song';
    likeButton.addEventListener(`click`, () => {
      const currentLikes = Number(totalLikes.textContent.split(': ')[1]);
      totalLikes.textContent = `Total Likes: ${currentLikes + 1}`;
      likeButton.disabled = true;
    });

    const deleteButton = document.createElement('button');
    deleteButton.classList.add('delete-btn');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener(`click`, () => {
      hitsInfoDiv.remove();
    });
    hitsInfoDiv.appendChild(img);
    hitsInfoDiv.appendChild(genreHeading);
    hitsInfoDiv.appendChild(nameHeading);
    hitsInfoDiv.appendChild(authorHeading);
    hitsInfoDiv.appendChild(dateHeading);
    hitsInfoDiv.appendChild(saveButton);
    hitsInfoDiv.appendChild(likeButton);
    hitsInfoDiv.appendChild(deleteButton);

    saveButton.addEventListener(`click`, () => {
      likeButton.remove();
      saveButton.remove();
      savedContainer.appendChild(hitsInfoDiv);
    });
    allHitsContainer.appendChild(hitsInfoDiv);

    genreInput.value = '';
    nameInput.value = '';
    authorInput.value = '';
    dateInput.value = '';
  });
}