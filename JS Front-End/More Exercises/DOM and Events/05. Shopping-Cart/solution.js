function solve() {
  let addBtnsArr = [...document.querySelectorAll(`.add-product`)];
  let textArea = document.querySelector(`textarea`);
  let names = new Set();
  let sum = 0;
  for (let addBtnEl of addBtnsArr) {
    addBtnEl.addEventListener(`click`, () => {
      let row = addBtnEl.parentElement.parentElement;
      let title = row.querySelector(`.product-title`).innerText;
      names.add(title);
      let costEl = row.querySelector(`.product-line-price`);
      let costNum = Number(costEl.innerText);
      sum += costNum;
      textArea.textContent += `Added ${title} for ${costNum.toFixed(2)} to the cart.\n`;
    });
  }
  let checkoutBtn = document.querySelector(`.checkout`);
  checkoutBtn.addEventListener(`click`, () => {
    textArea.textContent += `You bought ${[...names].join(`, `)} for ${sum.toFixed(2)}.`;
    checkoutBtn.disabled = true;
    addBtnsArr.forEach(x => x.disabled = true);
  });
}