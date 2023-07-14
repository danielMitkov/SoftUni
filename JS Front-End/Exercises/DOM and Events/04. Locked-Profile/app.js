function lockedProfile() {
  let buttons = document.querySelectorAll(`button`);
  for (let btn of buttons) {
    btn.addEventListener(`click`, (event) => {
      let parent = event.target.parentElement;
      let hidden = parent.querySelector(`div`);
      let lockRadio = parent.querySelector(`input[value="lock"]`);
      if (lockRadio.checked) {
        return;
      }
      if (hidden.style.display === `block`) {
        hidden.style.display = `none`;
        btn.textContent = `Show more`;
      } else {
        hidden.style.display = `block`;
        btn.textContent = `Hide it`;
      }
    });
  }
}