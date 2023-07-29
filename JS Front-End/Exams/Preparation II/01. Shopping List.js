function solve(input) {
  let groceries = [...input.shift().split('!')];
  for (const command of input) {
    if (command === 'Go Shopping!') {
      break;
    }
    const tokens = command.split(' ');
    const action = tokens[0];
    const item = tokens[1];
    switch (action) {
      case 'Urgent':
        if (!groceries.includes(item)) {
          groceries.unshift(item);
        }
        break;
      case 'Unnecessary':
        if (groceries.includes(item)) {
          groceries = groceries.filter(g => g !== item);
        }
        break;
      case 'Correct':
        const newItem = tokens[2];
        if (groceries.includes(item)) {
          const index = groceries.indexOf(item);
          groceries[index] = newItem;
        }
        break;
      case 'Rearrange':
        if (groceries.includes(item)) {
          groceries = groceries.filter(g => g !== item);
          groceries.push(item);
        }
        break;
    }
  }
  console.log(groceries.join(', '));
}