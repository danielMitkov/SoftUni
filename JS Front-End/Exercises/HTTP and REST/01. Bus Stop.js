async function getInfo() {
  let liElements = [...document.querySelectorAll(`#buses li`)];
  liElements.forEach(li => li.remove());
  let id = document.querySelector(`#stopId`).value;
  let data;
  let nameEl = document.querySelector(`#stopName`);
  try {
    let response = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${id}`);
    if (!response.ok) {
      throw new Error(response.status);
    }
    data = await response.json();
  } catch (err) {
    console.log(`Error: ${err.message}`);
    nameEl.textContent = `Error`;
    return;
  }
  nameEl.textContent = data.name;
  let ul = document.querySelector(`#buses`);
  for (let busNum in data.buses) {
    let li = document.createElement(`li`);
    li.textContent = `Bus ${busNum} arrives in ${data.buses[busNum]} minutes`;
    ul.appendChild(li);
  }
}