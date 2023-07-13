function deleteByEmail() {
  const email = document.querySelector('label input');
  const rows = document.querySelectorAll('tbody tr');
  const result = document.getElementById('result');
  for (let row of rows) {
    const tableEmail = row.children[1];
    if (tableEmail.textContent === email.value) {
      row.remove();
      result.textContent = 'Deleted.';
      return;
    }
  }
  result.textContent = 'Not found.';
}