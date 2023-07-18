function solve() {
  let selectToEl = document.querySelector(`#selectMenuTo`);

  let optionBinaryEl = selectToEl.querySelector(`option`);
  optionBinaryEl.textContent = `Binary`;
  optionBinaryEl.value = `binary`;

  let optionHexEl = document.createElement(`option`);
  optionHexEl.textContent = `Hexadecimal`;
  optionHexEl.value = `hexadecimal`;

  selectToEl.appendChild(optionHexEl);

  let btnEl = document.querySelector(`button`);
  btnEl.addEventListener(`click`, () => {
    let inputEl = document.querySelector(`#input`);
    let outputEl = document.querySelector(`#result`);
    if (optionBinaryEl.selected) {
      outputEl.value = Number(inputEl.value).toString(2);
    } else {
      outputEl.value = Number(inputEl.value).toString(16).toUpperCase();
    }
  });
}