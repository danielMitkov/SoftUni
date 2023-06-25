function WeirdSort(nums) {
    nums.sort((a, b) => a - b);
    const result = [];
    while (nums.length > 0) {
        result.push(nums.shift());
        result.push(nums.pop());
    }
    return result;
}