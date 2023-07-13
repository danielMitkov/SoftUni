function addItem() {
  let ul = document.getElementById(`items`);
  let textToAdd = document.getElementById(`newItemText`).value;
  let li = document.createElement(`li`);
  li.textContent = textToAdd;
  ul.appendChild(li);
}