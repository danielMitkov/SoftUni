function solve() {
  let correctCount = 0;
  let sections = [...document.querySelectorAll(`section`)];
  let btnOnClick = sections[0].querySelectorAll(`.answer-wrap`)[0];
  btnOnClick.addEventListener(`click`, () => {
    correctCount++;
    sections[0].style.display = `none`;
    sections[1].style.display = `block`;
  });
  let btnOnMouse = sections[0].querySelectorAll(`.answer-wrap`)[1];
  btnOnMouse.addEventListener(`click`, () => {
    sections[0].style.display = `none`;
    sections[1].style.display = `block`;
  });
  let btnToStr = sections[1].querySelectorAll(`.answer-wrap`)[0];
  btnToStr.addEventListener(`click`, () => {
    sections[1].style.display = `none`;
    sections[2].style.display = `block`;
  });
  let btnStrgify = sections[1].querySelectorAll(`.answer-wrap`)[1];
  btnStrgify.addEventListener(`click`, () => {
    correctCount++;
    sections[1].style.display = `none`;
    sections[2].style.display = `block`;
  });
  function ShowResult() {
    let results = document.querySelector(`#results`);
    results.style.display = `block`;
    let resultH1 = document.querySelector(`#results h1`);
    if (correctCount === 3) {
      resultH1.textContent = `You are recognized as top JavaScript fan!`;
    } else {
      resultH1.textContent = `You have ${correctCount} right answers`;
    }
  }
  let btnAPI = sections[2].querySelectorAll(`.answer-wrap`)[0];
  btnAPI.addEventListener(`click`, () => {
    correctCount++;
    sections[2].style.display = `none`;
    ShowResult();
  });
  let btnSource = sections[2].querySelectorAll(`.answer-wrap`)[1];
  btnSource.addEventListener(`click`, () => {
    sections[2].style.display = `none`;
    ShowResult();
  });
}