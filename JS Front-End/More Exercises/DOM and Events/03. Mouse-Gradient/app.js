function attachGradientEvents() {
  let box = document.querySelector(`#gradient`);
  let result = document.querySelector(`#result`);
  box.addEventListener(`mousemove`, (event) => {
    let offset = event.offsetX;
    let width = box.clientWidth;
    let percent = parseInt((offset / width) * 100);
    result.textContent = `${percent}%`;
  });
}