window.addEventListener('load', solve);
function solve() {
  const title = document.querySelector('#title');
  const description = document.querySelector('#description');
  const select = document.querySelector('#label');
  const points = document.querySelector('#points');
  const assignee = document.querySelector('#assignee');
  const section = document.querySelector('#tasks-section');
  const hidden = document.querySelector('#task-id');
  const totalPoints = document.querySelector('#total-sprint-points');
  const delTaskBtn = document.querySelector('#delete-task-btn');
  const createBtn = document.querySelector('#create-task-btn');
  createBtn.addEventListener('click', () => {
    if (title.value === '' || description.value === '' || points.value === '' || assignee === '') {
      return;
    }
    const article = document.createElement('article');
    article.classList.add('task-card');
    const articlesArr = [...section.querySelectorAll('article')];
    console.log(articlesArr);
    const id = articlesArr.length + 1;
    console.log(id);
    article.id = 'task-' + id;
    const numTotalPoints = parseInt(totalPoints.textContent.match(/\d+/));
    totalPoints.textContent = `Total Points ${numTotalPoints + Number(points.value)}pts`;
    let icon = 'NONE';
    let selectClass = 'NONE';
    if (select.value === 'Feature') {
      icon = '&#8865;';
      selectClass = 'feature';
    }
    if (select.value === 'Low Priority Bug') {
      icon = '&#9737;';
      selectClass = 'low-priority';
    }
    if (select.value === 'High Priority Bug') {
      icon = '&#9888;';
      selectClass = 'high-priority';
    }
    article.innerHTML = `
    <div class="task-card-label ${selectClass}">${select.value} ${icon}</div>
    <h3 class="task-card-title">${title.value}</h3>
    <p class="task-card-description">${description.value}</p>
    <div class="task-card-points">Estimated at ${points.value} pts</div>
    <div class="task-card-assignee">Assigned to: ${assignee.value}</div>
    <div class="task-card-actions">
      <button>Delete</button>
    </div>`;
    const titleCopy = title.value;
    const descriptionCopy = description.value;
    const selectCopy = select.value;
    const pointsCopy = points.value;
    const assigneeCopy = assignee.value;
    const delBtn = article.querySelector('button');
    delBtn.addEventListener('click', () => {
      title.value = titleCopy;
      description.value = descriptionCopy;
      select.value = selectCopy;
      points.value = pointsCopy;
      assignee.value = assigneeCopy;
      delTaskBtn.disabled = false;
      createBtn.disabled = true;
      title.disabled = true;
      description.disabled = true;
      select.disabled = true;
      points.disabled = true;
      assignee.disabled = true;
      hidden.value = article.id;
      hidden.setAttribute('data-points', points.value);
    });
    section.appendChild(article);
    title.value = '';
    description.value = '';
    select.value = 'Feature';
    points.value = '';
    assignee.value = '';
  });
  delTaskBtn.addEventListener('click', () => {
    const numTotalPoints = parseInt(totalPoints.textContent.match(/\d+/));
    totalPoints.textContent = `Total Points ${numTotalPoints - Number(hidden.getAttribute('data-points'))}pts`;
    const articleToDel = document.querySelector(`#${hidden.value}`);
    articleToDel.remove();
    title.disabled = false;
    description.disabled = false;
    select.disabled = false;
    points.disabled = false;
    assignee.disabled = false;
    delTaskBtn.disabled = true;
    createBtn.disabled = false;
    title.value = '';
    description.value = '';
    select.value = 'Feature';
    points.value = '';
    assignee.value = '';
  });
}