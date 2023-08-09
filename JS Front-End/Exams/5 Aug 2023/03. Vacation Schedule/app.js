window.addEventListener('load', solve);
function solve() {
  const loadBtn = document.querySelector('#load-vacations');
  const list = document.querySelector('#list');
  const addBtn = document.querySelector('#add-vacation');
  const nameEl = document.querySelector('#name');
  const daysEl = document.querySelector('#num-days');
  const dateEl = document.querySelector('#from-date');
  const editBtn = document.querySelector('#edit-vacation');
  let editId = null;
  loadBtn.addEventListener('click', async () => {
    list.innerHTML = '';
    const responseLoad = await fetch('http://localhost:3030/jsonstore/tasks');
    const answerLoad = await responseLoad.json();
    console.log(responseLoad.status);
    console.log(answerLoad);
    for (let obj of Object.values(answerLoad)) {

      const box = document.createElement('div');
      box.classList.add('container');
      list.appendChild(box);

      const h2 = document.createElement('h2');
      h2.textContent = obj.name;
      box.appendChild(h2);

      const h3Date = document.createElement('h3');
      h3Date.textContent = obj.date;
      box.appendChild(h3Date);

      const h3Days = document.createElement('h3');
      h3Days.textContent = obj.days;
      box.appendChild(h3Days);

      const changeBtn = document.createElement('button');
      changeBtn.classList.add('change-btn');
      changeBtn.textContent = 'Change';
      box.appendChild(changeBtn);
      changeBtn.addEventListener('click', () => {
        box.remove();
        nameEl.value = h2.textContent;
        dateEl.value = h3Date.textContent;
        daysEl.value = h3Days.textContent;
        editBtn.disabled = false;
        addBtn.disabled = true;
        editId = obj._id;
      });
      const doneBtn = document.createElement('button');
      doneBtn.classList.add('done-btn');
      doneBtn.textContent = 'Done';
      box.appendChild(doneBtn);
      doneBtn.addEventListener('click', async () => {
        const responseDone = await fetch(`http://localhost:3030/jsonstore/tasks/${obj._id}`, {
          method: 'DELETE'
        });
        const answerDone = await responseDone.json();
        console.log(responseDone.status);
        console.log(answerDone);
        loadBtn.click();
      });
    }
  });
  addBtn.addEventListener('click', async (event) => {
    event.preventDefault();
    // if (nameEl.value === '' || daysEl.value === '' || dateEl.value === '') {
    //   return;
    // }
    const responseAdd = await fetch('http://localhost:3030/jsonstore/tasks', {
      method: 'POST',
      body: JSON.stringify({
        date: dateEl.value,
        days: daysEl.value,
        name: nameEl.value
      })
    });
    nameEl.value = '';
    daysEl.value = '';
    dateEl.value = '';
    const answerAdd = await responseAdd.json();
    console.log(responseAdd.status);
    console.log(answerAdd);
    loadBtn.click();
  });
  editBtn.addEventListener('click', async (event) => {
    event.preventDefault();
    const responseEdit = await fetch(`http://localhost:3030/jsonstore/tasks/${editId}`, {
      method: 'PUT',
      body: JSON.stringify({
        date: dateEl.value,
        days: daysEl.value,
        name: nameEl.value,
        //_id: editId
      })
    });
    const answerEdit = await responseEdit.json();
    console.log(responseEdit.status);
    console.log(answerEdit);
    loadBtn.click();
    editBtn.disabled = true;
    addBtn.disabled = false;
    nameEl.value = '';
    daysEl.value = '';
    dateEl.value = '';
  });
}