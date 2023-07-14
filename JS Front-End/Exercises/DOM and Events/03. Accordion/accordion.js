function toggle() {
  let text = document.querySelector(`#extra`);
  let btn = document.querySelector(`.button`);
  if (text.style.display === `block`) {
    text.style.display = `none`;
    btn.textContent = `More`;
  } else {
    text.style.display = `block`;
    btn.textContent = `Less`;
  }
}