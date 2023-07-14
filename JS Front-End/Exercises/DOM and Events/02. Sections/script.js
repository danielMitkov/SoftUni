function create(words) {
  let container = document.querySelector(`#content`);
  for (let wordStr of words) {
    let p = document.createElement(`p`);
    p.textContent = wordStr;
    p.style.display = `none`;
    let div = document.createElement(`div`);
    div.appendChild(p);
    div.addEventListener(`click`, () => {
      p.style.display = `inline-block`;
    });
    container.appendChild(div);
  }
}