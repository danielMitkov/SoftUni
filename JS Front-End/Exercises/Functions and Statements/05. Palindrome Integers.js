function PrintCheckPalindromeNums(nums) {
    for (let num of nums) {
        const numString = String(num);
        const reversedString = numString.split('').reverse().join('');
        console.log(numString === reversedString);
    }
}