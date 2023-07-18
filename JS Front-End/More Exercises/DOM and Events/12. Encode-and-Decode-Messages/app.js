function encodeAndDecodeMessages() {
  let encode = document.querySelector(`button`);
  let resultTextArea = document.querySelectorAll(`textarea`)[1];
  function processMsg(msg, valueToAdd) {
    let msgEncoded = "";
    for (let i = 0; i < msg.length; i++) {
      let char = msg[i];
      let charCode = char.charCodeAt(0);
      let modifiedCharCode = charCode + valueToAdd;
      let modifiedCharStr = String.fromCharCode(modifiedCharCode);
      msgEncoded += modifiedCharStr;
    }
    return msgEncoded;
  }
  encode.addEventListener(`click`, () => {
    let inputArea = document.querySelector(`textarea`);
    let msg = inputArea.value;
    inputArea.value = ``;
    let msgEncoded = processMsg(msg, 1);
    resultTextArea.value = msgEncoded;
  });
  let decode = document.querySelectorAll(`button`)[1];
  decode.addEventListener(`click`, () => {
    let msgEncoded = resultTextArea.value;
    let msgDecoded = processMsg(msgEncoded, -1);
    resultTextArea.value = msgDecoded;
  });
}
//test input
//The password for my bank account is 123pass321