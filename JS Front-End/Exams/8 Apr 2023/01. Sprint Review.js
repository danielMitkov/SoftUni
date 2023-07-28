function sprintReview(input) {
  const n = Number(input.shift());
  const data = input.slice(0, n);
  const commands = input.slice(n);
  const people = {};
  for (let entry of data) {
    const [name, id, title, status, points] = entry.split(':');
    if (!(name in people)) {
      people[name] = [];
    }
    people[name].push({ name, id, title, status, points: Number(points) });
  }
  for (let command of commands) {
    const [action, ...args] = command.split(':');
    if (action === 'Add New') {
      const [name, id, title, status, points] = args;
      if (!(name in people)) {
        console.log(`Assignee ${name} does not exist on the board!`);
        continue;
      }
      people[name].push({ name, id, title, status, points: Number(points) });
    }
    if (action === 'Change Status') {
      const [name, id, newStatus] = args;
      if (!(name in people)) {
        console.log(`Assignee ${name} does not exist on the board!`);
        continue;
      }
      const taskIndex = people[name].findIndex(x => x.id === id);
      if (taskIndex === -1) {
        console.log(`Task with ID ${id} does not exist for ${name}!`);
        continue;
      }
      people[name][taskIndex].status = newStatus;
    }
    if (action === 'Remove Task') {
      let [name, taskIndex] = args;
      taskIndex = Number(taskIndex);
      if (!(name in people)) {
        console.log(`Assignee ${name} does not exist on the board!`);
        continue;
      }
      if (taskIndex < 0 || taskIndex >= people[name].length) {
        console.log('Index is out of range!');
        continue;
      }
      people[name].splice(taskIndex, 1);
    }
  }
  let pointsToDo = 0;
  let pointsInProgress = 0;
  let pointsReview = 0;
  let pointsDone = 0;
  for (let name in people) {
    for (let task of people[name]) {
      if (task.status === 'ToDo') {
        pointsToDo += task.points;
      }
      if (task.status === 'In Progress') {
        pointsInProgress += task.points;
      }
      if (task.status === 'Code Review') {
        pointsReview += task.points;
      }
      if (task.status === 'Done') {
        pointsDone += task.points;
      }
    }
  }
  console.log(`ToDo: ${pointsToDo}pts`);
  console.log(`In Progress: ${pointsInProgress}pts`);
  console.log(`Code Review: ${pointsReview}pts`);
  console.log(`Done Points: ${pointsDone}pts`);
  const sumOthers = pointsToDo + pointsInProgress + pointsReview;
  if (pointsDone >= sumOthers) {
    console.log('Sprint was successful!');
  } else {
    console.log('Sprint was unsuccessful...');
  }
}