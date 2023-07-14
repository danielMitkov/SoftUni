function solve() {
  document.querySelector('#searchBtn').addEventListener('click', onClick);

  function onClick() {
    let rowsElArr = [...document.querySelectorAll(`tbody tr`)];
    let targetStr = document.querySelector(`#searchField`).value;
    for (let rowEl of rowsElArr) {
      if (rowEl.innerText.includes(targetStr)) {
        rowEl.className = `select`;
      } else {
        rowEl.className = ``;
      }
    }
  }
}