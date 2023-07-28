window.addEventListener('load', attachEvents);
function attachEvents() {
  const ulToDo = document.querySelector('#todo-section ul');
  const ulProgress = document.querySelector('#in-progress-section ul');
  const ulReview = document.querySelector('#code-review-section ul');
  const ulDone = document.querySelector('#done-section ul');
  const fieldTitle = document.querySelector('#title');
  const fieldDescr = document.querySelector('#description');
  const btnAdd = document.querySelector('#create-task-btn');
  const btnLoad = document.querySelector('#load-board-btn');
  btnLoad.addEventListener('click', async () => {
    ulToDo.innerHTML = '';
    ulProgress.innerHTML = '';
    ulReview.innerHTML = '';
    ulDone.innerHTML = '';
    const responseLoad = await fetch('http://localhost:3030/jsonstore/tasks/');
    const answerLoad = await responseLoad.json();
    for (let key in answerLoad) {
      const obj = answerLoad[key];
      let btnText = 'EMPTY';
      if (obj.status === 'ToDo') {
        btnText = 'Move to In Progress';
      }
      if (obj.status === 'In Progress') {
        btnText = 'Move to Code Review';
      }
      if (obj.status === 'Code Review') {
        btnText = 'Move to Done';
      }
      if (obj.status === 'Done') {
        btnText = 'Close';
      }
      const li = document.createElement('li');
      li.className = 'task';
      const h3 = document.createElement('h3');
      h3.textContent = obj.title;
      li.appendChild(h3);
      const p = document.createElement('p');
      p.textContent = obj.description;
      li.appendChild(p);
      const btnMove = document.createElement('button');
      btnMove.textContent = btnText;
      btnMove.id = obj._id;
      btnMove.addEventListener('click', async () => {
        if (obj.status === 'Done') {
          await fetch(`http://localhost:3030/jsonstore/tasks/${btnMove.id}`, { method: 'DELETE' });
          btnLoad.click();
          return;
        }
        let newStatus = 'EMPTY';
        if (obj.status === 'ToDo') {
          newStatus = 'In Progress';
        }
        if (obj.status === 'In Progress') {
          newStatus = 'Code Review';
        }
        if (obj.status === 'Code Review') {
          newStatus = 'Done';
        }
        await fetch(`http://localhost:3030/jsonstore/tasks/${btnMove.id}`, {
          method: 'PATCH',
          body: JSON.stringify({ status: newStatus })
        });
        btnLoad.click();
      });
      li.appendChild(btnMove);
      if (obj.status === 'ToDo') {
        ulToDo.appendChild(li);
      }
      if (obj.status === 'In Progress') {
        ulProgress.appendChild(li);
      }
      if (obj.status === 'Code Review') {
        ulReview.appendChild(li);
      }
      if (obj.status === 'Done') {
        ulDone.appendChild(li);
      }
    }
  });
  btnAdd.addEventListener('click', async () => {
    await fetch('http://localhost:3030/jsonstore/tasks/', {
      method: 'POST',
      body: JSON.stringify({
        title: fieldTitle.value,
        description: fieldDescr.value,
        status: 'ToDo'
      })
    });
    fieldTitle.value = '';
    fieldDescr.value = '';
    btnLoad.click();
  });
}