function attachEvents() {
  const input = document.querySelector(`#location`);
  const btn = document.querySelector(`#submit`);
  const sectionOutput = document.querySelector(`#forecast`);
  btn.addEventListener(`click`, async () => {
    const responseLocations = await fetch(`http://localhost:3030/jsonstore/forecaster/locations`);
    const locations = await responseLocations.json();
    const targetObj = locations.find(obj => obj.name === input.value);
    const responseToday = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${targetObj.code}`);
    const today = await responseToday.json();
    sectionOutput.style.display = `block`;
    const symbols = {
      'Sunny': '&#x2600',
      'Partly sunny': '&#x26C5',
      'Overcast': '&#x2601',
      'Rain': '&#x2614',
      'Degrees': '&#176'
    };
    const divCurrent = document.querySelector(`#current`);
    divCurrent.innerHTML += `
    <div class="forecasts">
      <span class="condition symbol">${symbols[today.forecast.condition]}</span>
      <span class="condition">
        <span class="forecast-data">${today.name}</span>
        <span class="forecast-data">${today.forecast.low}°/${today.forecast.high}°</span>
        <span class="forecast-data">${today.forecast.condition}</span>
      </span>
    </div>`;
    const response = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${targetObj.code}`);
    const days = await response.json();
    const divForecastInfo = document.createElement(`div`);
    divForecastInfo.classList.add(`forecast-info`);
    for (let i = 0; i < 3; ++i) {
      divForecastInfo.innerHTML += `
      <span class="upcoming">
        <span class="symbol">${symbols[days.forecast[i].condition]}</span>
        <span class="forecast-data">${days.forecast[i].low}°/${days.forecast[i].high}°</span>
        <span class="forecast-data">${days.forecast[i].condition}</span>
      </span>`;
    }
    const divUpcoming = document.querySelector(`#upcoming`);
    divUpcoming.appendChild(divForecastInfo);
  });
}
attachEvents();