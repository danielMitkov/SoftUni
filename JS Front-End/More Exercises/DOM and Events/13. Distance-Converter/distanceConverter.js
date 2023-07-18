function attachEventsListeners() {
  let btn = document.querySelector(`#convert`);
  btn.addEventListener(`click`, () => {
    let valueInput = Number(document.querySelector(`#inputDistance`).value);
    let unitFrom = document.querySelector(`#inputUnits`).value;
    let unitTo = document.querySelector(`#outputUnits`).value;
    let units = {
      km: 1000,
      m: 1,
      cm: 0.01,
      mm: 0.001,
      mi: 1609.34,
      yrd: 0.9144,
      ft: 0.3048,
      in: 0.0254
    }
    let meters = valueInput * units[unitFrom];
    let valueOutput = meters / units[unitTo];
    let output = document.querySelector(`#outputDistance`);
    output.value = valueOutput;
  });
}