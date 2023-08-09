window.addEventListener("load", solve);

function solve() {
  const name = document.querySelector('#student');
  const uni = document.querySelector('#university');
  const score = document.querySelector('#score');
  const nextBtn = document.querySelector('#next-btn');
  const previewUl = document.querySelector('#preview-list');
  const candidateUl = document.querySelector('#candidates-list');
  nextBtn.addEventListener('click', (event) => {
    event.preventDefault();
    if (name.value === '' || uni.value === '' || score.value === '') {
      return;
    }
    const nameCurrent = name.value;
    const uniCurrent = uni.value;
    const scoreCurrent = score.value;
    const li = document.createElement('li');
    li.classList.add('application');
    previewUl.appendChild(li);

    const article = document.createElement('article');
    li.appendChild(article);

    const h4 = document.createElement('h4');
    h4.textContent = name.value;
    article.appendChild(h4);

    const pUni = document.createElement('p');
    pUni.textContent = 'University: ' + uni.value;
    article.appendChild(pUni);

    const pScore = document.createElement('p');
    pScore.textContent = 'Score: ' + score.value;
    article.appendChild(pScore);

    const editBtn = document.createElement('button');
    editBtn.classList.add('action-btn');
    editBtn.classList.add('edit');
    editBtn.textContent = 'edit';
    li.appendChild(editBtn);
    editBtn.addEventListener('click', () => {
      name.value = nameCurrent;
      uni.value = uniCurrent;
      score.value = scoreCurrent;
      li.remove();
      nextBtn.disabled = false;
    });
    const applyBtn = document.createElement('button');
    applyBtn.classList.add('action-btn');
    applyBtn.classList.add('apply');
    applyBtn.textContent = 'apply';
    li.appendChild(applyBtn);
    applyBtn.addEventListener('click', () => {
      li.remove();
      editBtn.remove();
      applyBtn.remove();
      nextBtn.disabled = false;
      candidateUl.appendChild(li);
    });
    nextBtn.disabled = true;
    name.value = '';
    uni.value = '';
    score.value = '';
  });
}