function generateReport() {
  let categoriesArr = [...document.querySelectorAll(`thead input`)];
  let flagsArr = [];
  for (let el of categoriesArr) {
    if (el.checked) {
      flagsArr.push([el.name, true]);
    } else {
      flagsArr.push([el.name, false]);
    }
  }
  let rowObjArr = [];
  let rowsArr = [...document.querySelectorAll(`tbody tr`)];
  for (let rowEl of rowsArr) {
    let tdArr = [...rowEl.querySelectorAll(`td`)];
    let rowObj = {};
    for (let i = 0; i < flagsArr.length; ++i) {
      if (flagsArr[i][1]) {
        rowObj[flagsArr[i][0]] = tdArr[i].textContent;
      }
    }
    rowObjArr.push(rowObj);
  }
  let resultEl = document.querySelector(`#output`);
  resultEl.value = JSON.stringify(rowObjArr);
}