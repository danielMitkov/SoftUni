function solve() {
  let textStr = document.querySelector(`#input`).value;
  let dotLessSentencesStrArr = textStr.split(`.`);
  dotLessSentencesStrArr.pop();//last empty
  let pCount = Math.ceil(dotLessSentencesStrArr.length / 3);
  let outputEl = document.querySelector(`#output`);
  for (let n = pCount; n > 0; --n) {
    let p = document.createElement(`p`);
    let pMadeCount = 0;
    while (dotLessSentencesStrArr.length > 0 && pMadeCount < 3) {
      let sentenceStr = dotLessSentencesStrArr.shift() + `.`;
      p.textContent += sentenceStr;
      pMadeCount++;
    }
    outputEl.appendChild(p);
  }
}