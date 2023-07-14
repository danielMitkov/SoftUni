function subtract() {
  let numA = Number(document.querySelector(`#firstNumber`).value);
  let numB = Number(document.querySelector(`#secondNumber`).value);
  document.querySelector(`#result`).textContent = numA - numB;
}