async function lockedProfile() {
  const response = await fetch(`http://localhost:3030/jsonstore/advanced/profiles`);
  const data = await response.json();
  const mainEl = document.querySelector(`main`);
  mainEl.innerHTML = ``;
  let userId = 1;
  for (let { age, email, username } of Object.values(data)) {
    const divProfile = document.createElement(`div`);
    divProfile.classList.add(`profile`);
    divProfile.innerHTML = `
    <img src="./iconProfile2.png" class="userIcon" />
    <label>Lock</label>
    <input type="radio" name="user`+ userId + `Locked" value="lock" checked>
    <label>Unlock</label>
    <input type="radio" name="user`+ userId + `Locked" value="unlock"><br>
    <hr>
    <label>Username</label>
    <input type="text" name="user1Username" value="${username}" disabled readonly />
    <div class="user1Username" style="display: none;">
      <hr>
      <label>Email:</label>
      <input type="email" name="user1Email" value="${email}" disabled readonly />
      <label>Age:</label>
      <input type="email" name="user1Age" value="${age}" disabled readonly />
    </div>
    <button>Show more</button>`;//notice age input type="email"
    mainEl.appendChild(divProfile);
    userId++;
  }
  let buttons = [...document.querySelectorAll(`button`)];
  for (let btn of buttons) {
    btn.addEventListener(`click`, (event) => {
      let parent = event.target.parentElement;
      let hidden = parent.querySelector(`div`);
      let lockRadio = parent.querySelector(`input[value="lock"]`);
      if (lockRadio.checked) {
        return;
      }
      if (hidden.style.display === `block`) {
        hidden.style.display = `none`;
        btn.textContent = `Show more`;
      } else {
        hidden.style.display = `block`;
        btn.textContent = `Hide it`;
      }
    });
  }
}