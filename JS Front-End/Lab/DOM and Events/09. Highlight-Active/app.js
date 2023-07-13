function focused() {
  let inputs = document.querySelectorAll(`input`);
  for (let input of inputs) {
    input.addEventListener(`focusin`, () => {
      input.parentElement.classList.add(`focused`);
    });
    input.addEventListener(`focusout`, () => {
      input.parentElement.classList.remove(`focused`);
    });
  }
}