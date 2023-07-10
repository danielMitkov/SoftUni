function storeStudentsAndCourses(input) {
  const courses = {};

  for (const line of input) {
    if (line.includes(':')) {
      const [courseName, capacity] = line.split(': ');
      if (!courses.hasOwnProperty(courseName)) {
        courses[courseName] = {
          capacity: Number(capacity),
          students: [],
        };
      } else {
        courses[courseName].capacity += Number(capacity);
      }
    } else if (line.includes('joins')) {
      const [studentInfo, courseName] = line.split(' joins ');
      const [username, credits, email] = studentInfo.match(/(\w+)\[(\d+)\] with email (\w+@\w+\.\w+)/).slice(1);
      if (courses.hasOwnProperty(courseName) && courses[courseName].students.length < courses[courseName].capacity) {
        courses[courseName].students.push({
          username,
          credits: Number(credits),
          email,
        });
      }
    }
  }

  const sortedCourses = Object.entries(courses).sort((a, b) => b[1].students.length - a[1].students.length);

  for (const [courseName, courseData] of sortedCourses) {
    const sortedStudents = courseData.students.sort((a, b) => b.credits - a.credits);
    console.log(`${courseName}: ${courseData.capacity - courseData.students.length} places left`);
    for (const student of sortedStudents) {
      console.log(`--- ${student.credits}: ${student.username}, ${student.email}`);
    }
  }
}
const input = [
  'JavaBasics: 2',
  'user1[25] with email user1@user.com joins C#Basics',
  'C#Advanced: 3',
  'JSCore: 4',
  'user2[30] with email user2@user.com joins C#Basics',
  'user13[50] with email user13@user.com joins JSCore',
  'user1[25] with email user1@user.com joins JSCore',
  'user8[18] with email user8@user.com joins C#Advanced',
  'user6[85] with email user6@user.com joins JSCore',
  'JSCore: 2',
  'user11[3] with email user11@user.com joins JavaBasics',
  'user45[105] with email user45@user.com joins JSCore',
  'user007[20] with email user007@user.com joins JSCore',
  'user700[29] with email user700@user.com joins JSCore',
  'user900[88] with email user900@user.com joins JSCore',
];

storeStudentsAndCourses(input);