function validate() {
  const regex = /^[a-z]+@[a-z]+\.[a-z]+$/;
  let emailInputEl = document.querySelector(`#email`);
  emailInputEl.addEventListener(`change`, (event) => {
    let match = emailInputEl.value.match(regex);
    if (match === null) {
      emailInputEl.classList.add(`error`);
    } else {
      emailInputEl.classList.remove(`error`);
    }
  });
}