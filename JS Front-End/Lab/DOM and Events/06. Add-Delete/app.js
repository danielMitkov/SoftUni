function addItem() {
  let ul = document.getElementById(`items`);
  let textToAdd = document.getElementById(`newItemText`).value;
  let li = document.createElement(`li`);
  let btn = document.createElement(`a`);
  function deleteLi() {
    li.remove();
  }
  btn.addEventListener(`click`, deleteLi);
  btn.href = `#`;
  btn.textContent = `[Delete]`;
  li.textContent = textToAdd;
  li.appendChild(btn);
  ul.appendChild(li);
}