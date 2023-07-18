function solve() {
  let tableEl = document.querySelector(`table`);
  let resultEl = document.querySelector(`#check p`);
  let clearBtn = document.querySelectorAll(`button`)[1];
  clearBtn.addEventListener(`click`, () => {
    let cells = [...document.querySelectorAll(`tbody input`)];
    cells.forEach(x => x.value = ``);
    tableEl.style.border = `none`;
    resultEl.textContent = ``;
  });
  let checkBtn = document.querySelector(`button`);
  checkBtn.addEventListener(`click`, () => {
    let isSolved = true;
    let rows = [...document.querySelectorAll(`tbody tr`)];
    let cols = [];
    for (let i = 0; i < rows.length; ++i) {
      let row = [];
      let rowInputs = [...rows[i].querySelectorAll(`input`)];
      for (let ii = 0; ii < rowInputs.length; ++ii) {
        let value = rowInputs[ii].value;
        if (row.includes(value)) {
          isSolved = false;
          break;
        }
        row.push(value);
        if (ii === cols.length) {
          cols.push([]);
        }
        if (cols[ii].includes(value)) {
          isSolved = false;
          break;
        }
        cols[ii].push(value);
      }
      if (!isSolved) {
        break;
      }
    }
    if (isSolved) {
      tableEl.style.border = `2px solid green`;
      resultEl.textContent = `You solve it! Congratulations!`;
      resultEl.style.color = `green`;
    } else {
      tableEl.style.border = `2px solid red`;
      resultEl.textContent = `NOP! You are not done yet...`;
      resultEl.style.color = `red`;
    }
  });
}