function search() {
  let liArr = [...document.querySelectorAll(`li`)];
  let matchStr = document.querySelector(`#searchText`).value;
  let count = 0;
  for (let li of liArr) {
    if (li.textContent.includes(matchStr)) {
      li.style.textDecoration = `underline`;
      li.style.fontWeight = `bold`;
      count++;
    } else {
      li.style.textDecoration = `none`;
      li.style.fontWeight = `normal`;
    }
  }
  let result = document.querySelector(`#result`);
  result.textContent = `${count} matches found`;
}