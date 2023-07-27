window.addEventListener('load', solve);
function solve() {
  const titleField = document.querySelector('#course-name');
  const typeField = document.querySelector('#course-type');
  const descrField = document.querySelector('#description');
  const teacherField = document.querySelector('#teacher-name');
  const addBtn = document.querySelector('#add-course');
  const editGlobalBtn = document.querySelector('#edit-course');
  let editId = null;
  const loadBtn = document.querySelector('#load-course');
  loadBtn.addEventListener('click', async () => {
    const responseLoad = await fetch('http://localhost:3030/jsonstore/tasks/');
    const tasksData = await responseLoad.json();
    const divList = document.querySelector('#list');
    divList.innerHTML = '';
    for (let id in tasksData) {
      const descr = tasksData[id].description;
      const teacher = tasksData[id].teacher;
      const title = tasksData[id].title;
      const type = tasksData[id].type;
      const _id = tasksData[id]._id;
      const containerEl = document.createElement('div');
      containerEl.classList.add('container');
      containerEl.innerHTML = `
      <h2>${title}</h2>
      <h3>${teacher}</h3>
      <h3>${type}</h3>
      <h4>${descr}</h4>
      <button class="edit-btn">Edit Course</button>
      <button class="finish-btn">Finish Course</button>`;
      divList.appendChild(containerEl);
      const editBtn = containerEl.querySelector('.edit-btn');
      editBtn.addEventListener('click', async () => {
        titleField.value = title;
        typeField.value = type;
        descrField.value = descr;
        teacherField.value = teacher;
        addBtn.disabled = true;
        editGlobalBtn.disabled = false;
        editId = _id;
        containerEl.remove();
      });
      const finishBtn = containerEl.querySelector('.finish-btn');
      finishBtn.addEventListener('click', async () => {
        await fetch(`http://localhost:3030/jsonstore/tasks/${_id}`, { method: 'DELETE' });
        loadBtn.click();
      });
    }
  });
  addBtn.addEventListener('click', async (event) => {
    event.preventDefault();
    await fetch('http://localhost:3030/jsonstore/tasks/', {
      method: 'POST',
      body: JSON.stringify({
        description: descrField.value,
        teacher: teacherField.value,
        title: titleField.value,
        type: typeField.value
      })
    });
    titleField.value = '';
    typeField.value = '';
    descrField.value = '';
    teacherField.value = '';
    loadBtn.click();
  });
  editGlobalBtn.addEventListener('click', async (event) => {
    event.preventDefault();
    await fetch(`http://localhost:3030/jsonstore/tasks/${editId}`, {
      method: 'PUT',
      body: JSON.stringify({
        description: descrField.value,
        teacher: teacherField.value,
        title: titleField.value,
        type: typeField.value,
        _id: editId
      })
    });
    editGlobalBtn.disabled = true;
    addBtn.disabled = false;
    loadBtn.click();
  });
}