function PrintGrades(data) {
    let dictGradeStudentListObj = {};
    for (let studentStr of data) {
        let [nameStr, gradeStr, scoreStr] = studentStr.split(`, `);
        let name = nameStr.split(`: `)[1];
        let grade = Number(gradeStr.split(`: `)[1]);
        let score = Number(scoreStr.split(`: `)[1]);
        if (score < 3) {
            continue;
        }
        grade++;
        if (!(grade in dictGradeStudentListObj)) {
            dictGradeStudentListObj[grade] = {
                dictNameScore: {},
                getAverageScore() {
                    let scoreSum = 0;
                    let count = 0;
                    for (let name in this.dictNameScore) {
                        scoreSum += this.dictNameScore[name];
                        count++;
                    }
                    return scoreSum / count;
                }
            };
        }
        dictGradeStudentListObj[grade].dictNameScore[name] = score;
    }
    let sortedGrades = Object.entries(dictGradeStudentListObj).sort((a, b) => a - b);
    for (let year in dictGradeStudentListObj) {
        let namesArr = Object.keys(dictGradeStudentListObj[year].dictNameScore);
        let averageScore = dictGradeStudentListObj[year].getAverageScore();
        console.log(`${year} Grade`);
        console.log(`List of students: ${namesArr.join(`, `)}`);
        console.log(`Average annual score from last year: ${averageScore.toFixed(2)}`);
        console.log();
    }
}