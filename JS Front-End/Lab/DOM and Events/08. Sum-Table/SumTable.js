function sumTable() {
  let costs = [...document.querySelectorAll(`td:nth-child(2)`)].slice(0, -1).map(x => Number(x.textContent));
  let sum = 0;
  for (let price of costs) {
    sum += price;
  }
  document.querySelector(`#sum`).textContent = sum;
}