function solve() {
  let id = `depot`;
  let name = ``;
  let departBtn = document.querySelector(`#depart`);
  let arriveBtn = document.querySelector(`#arrive`);
  let statusTxt = document.querySelector(`.info`);
  async function depart() {
    departBtn.disabled = true;
    let data;
    try {
      let response = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${id}`);
      data = await response.json();
    } catch (err) {
      statusTxt.textContent = `Error`;
      return;
    }
    statusTxt.textContent = `Next stop ${data.name}`;
    id = data.next;
    name = data.name;
    arriveBtn.disabled = false;
  }

  function arrive() {
    arriveBtn.disabled = true;
    statusTxt.textContent = `Arriving at ${name}`;
    departBtn.disabled = false;
  }

  return {
    depart,
    arrive
  };
}

let result = solve();