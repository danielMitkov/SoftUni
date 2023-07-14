function solve() {
  let generateBtnEl = document.querySelector(`button`);
  generateBtnEl.addEventListener(`click`, (event) => {
    let inputJsonStr = document.querySelector(`textarea`).value;
    let objArr = JSON.parse(inputJsonStr);
    let tbody = document.querySelector(`tbody`);
    for (let obj of objArr) {
      let tr = document.createElement(`tr`);

      let td = document.createElement(`td`);
      let img = document.createElement(`img`);
      img.src = obj.img;
      td.appendChild(img);
      tr.appendChild(td);

      td = document.createElement(`td`);
      let p = document.createElement(`p`);
      p.textContent = obj.name;
      td.appendChild(p);
      tr.appendChild(td);

      td = document.createElement(`td`);
      p = document.createElement(`p`);
      p.textContent = obj.price;
      td.appendChild(p);
      tr.appendChild(td);

      td = document.createElement(`td`);
      p = document.createElement(`p`);
      p.textContent = obj.decFactor;
      td.appendChild(p);
      tr.appendChild(td);

      td = document.createElement(`td`);
      let input = document.createElement(`input`);
      input.type = `checkbox`;
      td.appendChild(input);
      tr.appendChild(td);

      tbody.appendChild(tr);
    }
  });
  let buyBtn = document.querySelectorAll(`button`)[1];
  buyBtn.addEventListener(`click`, (event) => {
    let rowsElArr = document.querySelectorAll(`tbody tr`);
    let namesArr = [];
    let totalPrice = 0;
    let totalDecFactor = 0;
    for (let rowEl of rowsElArr) {
      let checkbox = rowEl.querySelector(`input`);
      if (!checkbox.checked) {
        continue;
      }
      let tdArr = rowEl.querySelectorAll(`td`);
      let name = tdArr[1].textContent;
      let cost = Number(tdArr[2].textContent);
      let factor = Number(tdArr[3].textContent);
      namesArr.push(name);
      totalPrice += cost;
      totalDecFactor += factor;
    }
    let averageDecFactor = totalDecFactor / namesArr.length;
    let resultEl = document.querySelectorAll(`textarea`)[1];
    resultEl.value += `Bought furniture: ${namesArr.join(`, `)}\n`;
    resultEl.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    resultEl.value += `Average decoration factor: ${averageDecFactor}`;
  });
}