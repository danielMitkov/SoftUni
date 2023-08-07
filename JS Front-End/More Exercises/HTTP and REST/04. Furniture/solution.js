// zip this with index, login, home and homeLogged html files which are unchanged
function solve() {
  window.location.replace('home.html');
}
function chooseWhichCode() {
  const h2ElCheck = document.querySelector('h2');

  if (h2ElCheck && h2ElCheck.textContent === 'Register') {
    solveLogin();
  } else if (h2ElCheck && h2ElCheck.textContent === 'Create Product') {
    solveHomeLogged();
  } else if (document.querySelectorAll('a')[1].textContent === 'Login') {
    solveHome();
  }
}
chooseWhichCode();
async function load() {
  const responseLoad = await fetch('http://localhost:3030/data/furniture');
  const answerLoad = await responseLoad.json();
  for (let obj of answerLoad) {
    const tr = document.createElement('tr');
    document.querySelector('tbody').appendChild(tr);

    function createTableData(tag, prop, value) {

      const td = document.createElement('td');
      tr.appendChild(td);
      const el = document.createElement(tag);
      el[prop] = value;
      td.appendChild(el);
    }
    createTableData('img', 'src', obj.img);
    createTableData('p', 'textContent', obj.name);
    createTableData('p', 'textContent', obj.price);
    createTableData('p', 'textContent', obj.factor);
    createTableData('input', 'type', 'checkbox');
  }
}
async function solveHome() {
  window.addEventListener('load', load);
}
function solveLogin() {
  async function login(urlDetail, email, password) {

    const responseInfo = await fetch(`http://localhost:3030/users/${urlDetail}`, {
      method: 'POST',
      body: JSON.stringify({ email, password })
    });
    const answerInfo = await responseInfo.json();
    if (responseInfo.ok) {
      localStorage.setItem('loginInfo', JSON.stringify(answerInfo));
      window.location.replace('homeLogged.html');
    }
  }
  const formRegister = document.querySelector('form[action="/register"]');
  formRegister.id = 'register-form';
  formRegister.querySelector('button').addEventListener('click', async (event) => {
    event.preventDefault();
    const email = formRegister.querySelector('input[name="email"]').value;
    const pass = formRegister.querySelector('input[name="password"]').value;
    if (email === '' || pass === '') return;
    await login('register', email, pass);
  });
  const formLogin = document.querySelector('form[action="/login"]');
  formLogin.id = 'login-form';
  formLogin.querySelector('button').addEventListener('click', async (event) => {
    event.preventDefault();
    const email = formLogin.querySelector('input[name="email"]').value;
    const pass = formLogin.querySelector('input[name="password"]').value;
    await login('login', email, pass);
  });
}
async function solveHomeLogged() {
  window.addEventListener('load', load);
  const loginObj = JSON.parse(localStorage.getItem('loginInfo'));

  document.querySelector('#logoutBtn').addEventListener('click', async () => {

    await fetch('http://localhost:3030/users/logout', { headers: { 'X-Authorization': loginObj.accessToken } });
    localStorage.removeItem('loginInfo');
    window.location.replace('home.html');
  });
  document.querySelector('form').id = 'create-form';
  document.querySelector('form button').addEventListener('click', async (event) => {
    event.preventDefault();
    const [name, price, factor, img] = [...document.querySelectorAll('form input')].map(el => el.value);

    await fetch('http://localhost:3030/data/furniture', {
      method: 'POST',
      headers: { 'X-Authorization': loginObj.accessToken },
      body: JSON.stringify({ name, price, factor, img })
    });
    await load();
  });
  document.querySelectorAll('button')[1].addEventListener('click', async () => {//buy button
    const names = [];
    let sum = 0;
    for (let tr of [...document.querySelectorAll('tbody tr')]) {

      if (tr.querySelector('input').checked === false) {
        continue;
      }
      const pName = tr.querySelector('p');
      const pPrice = [...tr.querySelectorAll('p')][1];
      names.push(pName.textContent);
      sum += Number(pPrice.textContent);
    }
    await fetch('http://localhost:3030/data/orders', {
      method: 'POST',
      headers: { 'X-Authorization': loginObj.accessToken },
      body: JSON.stringify({ names, sum, _ownerId: loginObj._id })
    });
  });
  const btnOrders = document.querySelector('.orders button');
  btnOrders.id = 'show-orders-btn';
  btnOrders.addEventListener('click', async () => {

    const responseOrders = await fetch(`http://localhost:3030/data/orders?where=_ownerId%3D%22${loginObj._id}%22`);
    const answerOrders = await responseOrders.json();//%22 is "

    const spans = [...document.querySelectorAll('.orders span')];
    spans[0].textContent = 'Nothing bought yet!';
    spans[1].textContent = '0 $';

    if (responseOrders.ok) {
      const latestOrder = answerOrders.pop();

      if (latestOrder.names.length > 0) {

        spans[0].textContent = latestOrder.names.join(', ');
        spans[1].textContent = `${latestOrder.sum} $`;
      }
    }// if a test fails but works in the website, a possible explanation is:
  });// it's just javascript
  btnOrders.click();
}