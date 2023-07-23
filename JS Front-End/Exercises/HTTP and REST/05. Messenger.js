function attachEvents() {
  let nameEl = document.querySelector(`input[name="author"]`);
  let msgEl = document.querySelector(`input[name="content"]`);
  let textEl = document.querySelector(`#messages`);
  let btnSend = document.querySelector(`#submit`);
  btnSend.addEventListener(`click`, async () => {
    let obj = {
      author: nameEl.value,
      content: msgEl.value,
    };
    try {
      const response = await fetch(`http://localhost:3030/jsonstore/messenger`, {
        method: `POST`,
        headers: {
          'Content-Type': `application/json`
        },
        body: JSON.stringify(obj)
      });
      const result = await response.json();
    } catch (error) {
      return;
    }
  });
  let btnRefresh = document.querySelector(`#refresh`);
  btnRefresh.addEventListener(`click`, async () => {
    let data;
    try {
      const response = await fetch(`http://localhost:3030/jsonstore/messenger`);
      data = await response.json();
    } catch (err) {
      return;
    }
    let outputText = [];
    for (let id in data) {
      outputText.push(`${data[id].author}: ${data[id].content}`);
    }
    textEl.value = outputText.join(`\n`);
  });
}

attachEvents();