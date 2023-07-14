function addItem() {
  let textEl = document.querySelector(`#newItemText`);
  let valueEl = document.querySelector(`#newItemValue`);
  let text = textEl.value;
  let value = valueEl.value;
  textEl.value = ``;
  valueEl.value = ``;
  let option = document.createElement(`option`);
  option.textContent = text;
  option.value = value;
  let dropMenu = document.querySelector(`#menu`);
  dropMenu.appendChild(option);
}