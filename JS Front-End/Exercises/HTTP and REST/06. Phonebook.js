function attachEvents() {
  const ul = document.querySelector(`#phonebook`);
  const btnLoad = document.querySelector(`#btnLoad`);
  btnLoad.addEventListener('click', async () => {
    const response = await fetch(`http://localhost:3030/jsonstore/phonebook`);
    const data = await response.json();
    ul.innerHTML = ``;
    for (let entry of Object.values(data)) {
      const li = document.createElement(`li`);
      li.textContent = `${entry.person}: ${entry.phone}`;
      const btnDel = document.createElement(`button`);
      btnDel.textContent = `Delete`;
      btnDel.addEventListener(`click`, async () => {
        await fetch(`http://localhost:3030/jsonstore/phonebook/${entry._id}`, { method: `DELETE` });
        li.remove();
      });
      li.appendChild(btnDel);
      ul.appendChild(li);
    }
  });
  const btnCreate = document.querySelector(`#btnCreate`);
  btnCreate.addEventListener(`click`, async () => {
    const fieldPerson = document.querySelector(`#person`);
    const fieldPhone = document.querySelector(`#phone`);
    await fetch(`http://localhost:3030/jsonstore/phonebook`, {
      method: `POST`,
      body: JSON.stringify({
        person: fieldPerson.value,
        phone: fieldPhone.value
      })
    });
    fieldPerson.value = ``;
    fieldPhone.value = ``;
    btnLoad.click();
  });
}
attachEvents();