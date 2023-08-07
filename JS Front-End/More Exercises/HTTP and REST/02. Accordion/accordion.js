async function solution() {
  const responseTitles = await fetch(`http://localhost:3030/jsonstore/advanced/articles/list`);
  const titles = await responseTitles.json();
  const main = document.querySelector(`#main`);
  for (let { _id, title } of titles) {
    const div = document.createElement(`div`);
    div.classList.add(`accordion`);
    div.innerHTML = `
    <div class="head">
      <span>${title}</span>
      <button class="button" id="${_id}">More</button>
    </div>
    <div class="extra">
      <p></p>
    </div>`;
    main.appendChild(div);
    const btn = div.querySelector(`button`);
    btn.addEventListener(`click`, async () => {
      let contentEl = div.querySelector(`.extra`);
      if (contentEl.style.display === `block`) {
        contentEl.removeAttribute(`style`);
        btn.textContent = `More`;
      } else {
        const responseText = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${btn.id}`);
        const text = await responseText.json();
        const p = div.querySelector(`p`);
        p.textContent = text.content;
        contentEl.style.display = `block`;
        btn.textContent = `Less`;
      }
    });
  }
}
solution();