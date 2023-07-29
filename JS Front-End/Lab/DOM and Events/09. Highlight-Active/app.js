function focused() {
  const inputs = document.querySelectorAll(`input`);
  for (let input of inputs) {
    input.addEventListener(`focus`, () => {
      input.parentElement.classList.add(`focused`);
    });
    input.addEventListener(`blur`, () => {
      input.parentElement.classList.remove(`focused`);
    });
  }
}