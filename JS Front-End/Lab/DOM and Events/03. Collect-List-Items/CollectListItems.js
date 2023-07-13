function extractText() {
  const items = document.querySelectorAll('#items li');
  const box = document.getElementById('result');
  box.value = [...items].map(item => item.textContent).join('\n');
}