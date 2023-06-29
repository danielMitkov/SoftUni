function PrintIsPasswordValid(password) {
    function IsRightLength(str) {
        return str.length >= 6 && str.length <= 10;
    }
    function IsOnlyLettersAndDigits(str) {
        return /^[a-zA-Z0-9]+$/.test(str);
    }
    function HasAtLeastTwoDigits(str) {
        let digits = str.match(/\d/g);
        return digits !== null && digits.length >= 2;
    }
    if (IsRightLength(password) && IsOnlyLettersAndDigits(password) && HasAtLeastTwoDigits(password)) {
        console.log(`Password is valid`);
        return;
    }
    if (!IsRightLength(password)) {
        console.log(`Password must be between 6 and 10 characters`);
    }
    if (!IsOnlyLettersAndDigits(password)) {
        console.log(`Password must consist only of letters and digits`);
    }
    if (!HasAtLeastTwoDigits(password)) {
        console.log(`Password must have at least 2 digits`);
    }
}