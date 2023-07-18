function attachEventsListeners() {
  let days = document.querySelector(`#days`);
  let hours = document.querySelector(`#hours`);
  let minutes = document.querySelector(`#minutes`);
  let seconds = document.querySelector(`#seconds`);

  let daysBtn = document.querySelector(`#daysBtn`);
  daysBtn.addEventListener(`click`, () => {
    let d = days.value;
    hours.value = d * 24;
    minutes.value = hours.value * 60;
    seconds.value = minutes.value * 60;
  });
  let hoursBtn = document.querySelector(`#hoursBtn`);
  hoursBtn.addEventListener(`click`, () => {
    let h = hours.value;
    days.value = h / 24;
    minutes.value = h * 60;
    seconds.value = minutes.value * 60;
  });
  let minutesBtn = document.querySelector(`#minutesBtn`);
  minutesBtn.addEventListener(`click`, () => {
    let m = minutes.value;
    hours.value = m / 60;
    days.value = hours.value / 24;
    seconds.value = m * 60;
  });
  let secondsBtn = document.querySelector(`#secondsBtn`);
  secondsBtn.addEventListener(`click`, () => {
    let s = seconds.value;
    minutes.value = s / 60;
    hours.value = minutes.value / 60;
    days.value = hours.value / 24;
  });
}