window.addEventListener('load', solveSignUp);
function solveSignUp() {
  document.querySelector('#user').style.display = 'none';

  document.querySelector('button').addEventListener('click', async (event) => {
    event.preventDefault();
    const inputEmail = document.querySelector('input[name="email"]');
    const inputPass = document.querySelector('input[name="password"]');
    const inputRePass = document.querySelector('input[name="rePass"]');

    const pMessage = document.querySelector('.notification');

    if (inputPass.value !== inputRePass.value) {
      inputPass.value = '';
      inputRePass.value = '';
      pMessage.textContent = 'Passwords do not match';
      return;
    }
    const responseSignUp = await fetch('http://localhost:3030/users/register', {
      method: 'POST',
      body: JSON.stringify({
        email: inputEmail.value,
        password: inputPass.value
      })
    });
    const answerSignUp = await responseSignUp.json();

    if (!responseSignUp.ok) {
      inputEmail.value = '';
      inputPass.value = '';
      inputRePass.value = '';
      pMessage.textContent = answerSignUp.message;
      return;
    }
    localStorage.setItem('userInfo', JSON.stringify(answerSignUp));
    window.location.replace('index.html');
  });
}