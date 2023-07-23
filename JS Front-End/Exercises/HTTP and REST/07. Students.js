async function attachEvents() {
  async function getData() {
    const response = await fetch(`http://localhost:3030/jsonstore/collections/students`);
    const data = await response.json();
    const tbody = document.querySelector(`tbody`);
    tbody.innerHTML = ``;
    for (let entry of Object.values(data)) {
      const tr = document.createElement(`tr`);
      tr.innerHTML = `
      <td>${entry.firstName}</td>
      <td>${entry.lastName}</td>
      <td>${entry.facultyNumber}</td>
      <td>${entry.grade}</td>`;
      tbody.appendChild(tr);
    }
  }
  await getData();
  const fieldFirst = document.querySelector(`input[name="firstName"]`);
  const fieldLast = document.querySelector(`input[name="lastName"]`);
  const fieldFaculty = document.querySelector(`input[name="facultyNumber"]`);
  const fieldGrade = document.querySelector(`input[name="grade"]`);
  const btn = document.querySelector(`#submit`);
  btn.addEventListener(`click`, async () => {
    const studentObj = {
      firstName: fieldFirst.value,
      lastName: fieldLast.value,
      facultyNumber: fieldFaculty.value,
      grade: fieldGrade.value
    };
    await fetch(`http://localhost:3030/jsonstore/collections/students`, {
      method: `POST`,
      body: JSON.stringify(studentObj)
    });
    await getData();
  });
}
attachEvents();