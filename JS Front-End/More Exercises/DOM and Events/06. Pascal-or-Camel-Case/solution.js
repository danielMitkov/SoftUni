function solve() {
  let textStr = document.querySelector(`#text`).value;
  let caseStr = document.querySelector(`#naming-convention`).value;
  let resultEl = document.querySelector(`#result`);
  if (caseStr !== `Camel Case` && caseStr !== `Pascal Case`) {
    resultEl.textContent = `Error!`;
    return;
  }
  let strArr = textStr.toLowerCase().split(` `);
  let doneStr = strArr.map(s => s[0].toUpperCase() + s.slice(1)).join('');
  if (caseStr === `Camel Case`) {
    doneStr = doneStr[0].toLowerCase() + doneStr.slice(1);
  }
  resultEl.textContent = doneStr;
}