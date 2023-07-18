function extract(contentId) {
  let text = document.getElementById(contentId).textContent;
  var regExp = /\(([^)]+)\)/g;
  return [...text.matchAll(regExp)].map(x => x[1]).join(`; `);
}