window.addEventListener('load', solveLogin);
function solveLogin() {
  document.querySelector('#user').style.display = 'none';

  document.querySelector('button').addEventListener('click', async (event) => {
    event.preventDefault();
    const inputEmail = document.querySelector('input[name="email"]');
    const inputPass = document.querySelector('input[name="password"]');

    const responseLogin = await fetch('http://localhost:3030/users/login', {
      method: 'POST',
      body: JSON.stringify({
        email: inputEmail.value,
        password: inputPass.value
      })
    });
    const answerLogin = await responseLogin.json();

    if (!responseLogin.ok) {
      inputEmail.value = '';
      inputPass.value = '';
      document.querySelector('.notification').textContent = answerLogin.message;
      return;
    }
    localStorage.setItem('userInfo', JSON.stringify(answerLogin));
    window.location.replace('index.html');
  });
}