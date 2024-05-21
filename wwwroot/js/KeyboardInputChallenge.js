function print(data) {
    console.log(data);
} 
class Problem {
    constructor(id = 0, expression, rightAnswer, userAnswer = null, timeTaken = null, isSolved = false) {
        this.problemId = id; // This should be set by the server
        this.challengeId = challengeData.challengeId;
        this.userId = challengeData.userId;
        this.expression = expression;
        this.rightAnswer = rightAnswer;
        this.userAnswer = userAnswer;
        this.timeTaken = timeTaken;
        this.isSolved = isSolved;
    }
}

class Challenge {
    constructor(data) {
        Object.assign(this, data);
        this.isReviewSession = Array.isArray(data.problems) && data.problems.length > 0;
        this.solvedProblems = 0;
        this.misses = 0;
        this.speed = 0;
        this.accuracy = 0;
        this.startTime = new Date();
        this.finishTime = null;
        this.totalProblems = ((this.isReviewSession) ? data.problems.length : this.totalProblems);

        this.attemptedProblems = [];
        this.unattemptedProblems = [];
        this.operations = [];

        this.initializeOperations();
        this.initializeProblems();
        this.lastTime = new Date();
    }

    initializeOperations() {
        if (this.addition) this.operations.push("+");
        if (this.subtraction) this.operations.push("-");
        if (this.multiplication) this.operations.push("*");
        if (this.division) this.operations.push("/");
    }

    initializeProblems() {
        if (this.isReviewSession) {
            this.unattemptedProblems = this.problems.map(p => new Problem(p.problemId, p.expression, p.rightAnswer, p.userAnswer, p.timeTaken, p.isSolved));
        } else {
            for (let i = 0; i < this.totalProblems; i++) {
                this.unattemptedProblems.push(this.generateProblem());
            }
        }
        print(this.unattemptedProblems)
    }

    generateProblem() {
        const randomNumber1 = Math.floor(Math.random() * (this.maxNumber - this.minNumber + 1)) + this.minNumber;
        const randomNumber2 = Math.floor(Math.random() * (this.maxNumber - this.minNumber + 1)) + this.minNumber;
        const operation = this.operations[Math.floor(Math.random() * this.operations.length)];
        const problemText = `${randomNumber1} ${operation} ${randomNumber2} = ?`;
        const answer = eval(`${randomNumber1} ${operation} ${randomNumber2}`);
        return new Problem(0, problemText, answer);
    }

    recordTimeTaken() {
        const currentTime = new Date();
        const timeTaken = ((currentTime - this.lastTime) / 1000).toFixed(2);
        this.lastTime = currentTime;
        return timeTaken;
    }

    updateStats() {
        const totalProblemsAttempted = this.solvedProblems + this.misses;
        const elapsedTime = (new Date() - this.startTime) / 1000;
        this.finishTime = new Date();
        if (totalProblemsAttempted != 0) {
            this.speed = (elapsedTime / totalProblemsAttempted).toFixed(2);
            this.accuracy = ((this.solvedProblems / totalProblemsAttempted) * 100).toFixed(2);
        }


        UI.updateStats(this.solvedProblems, this.misses, this.unattemptedProblems.length, this.speed, this.accuracy);
    }

    updateProblemList(problem) {
        UI.updateProblemList(problem);
        this.attemptedProblems.push(problem);
    }

    addCircle(problem) {
        UI.addCircle(problem);
    }

    sendStatsToServer() {
        this.finishTime = new Date().toISOString();
        this.startTime = this.startTime.toISOString();
        debugger;

        if (isNaN(this.speed)) this.speed = 0;
        if (isNaN(this.accuracy)) this.accuracy = 0;

        const form = document.createElement('form');
        form.method = 'post';
        form.action = '/Challenges/ProcessChallengeData';

        const data = {
            ...this,
            problemsJson: JSON.stringify(this.attemptedProblems)
        };

        for (const key in data) {
            if (data.hasOwnProperty(key)) {
                const input = document.createElement('input');
                input.type = 'hidden';
                input.name = key;
                input.value = data[key];
                form.appendChild(input);
            }
        }

        document.body.appendChild(form);
        form.submit();
    }
}

class UI {
    static initElements() {
        this.timerElement = document.getElementById("timer");
        this.problemsLeftElement = document.getElementById("problemsLeft");
        this.solvedProblemsElement = document.getElementById("solvedProblems");
        this.missesElement = document.getElementById("misses");
        this.speedElement = document.getElementById("speed");
        this.accuracyElement = document.getElementById("accuracy");
        this.problemsTableBody = document.getElementById("problems");
        this.userAnswerElement = document.getElementById("userAnswer");
        this.feedbackElement = document.getElementById("feedback");
        this.circlesContainer = document.getElementById("circles");
        this.problemElement = document.getElementById("problem");
        this.userAnswerElement.focus();
    }

    static updateStats(solvedProblems, misses, problemsLeft, speed, accuracy) {
        this.solvedProblemsElement.textContent = solvedProblems;
        this.missesElement.textContent = misses;
        this.problemsLeftElement.textContent = problemsLeft;
        this.speedElement.textContent = speed;
        this.accuracyElement.textContent = accuracy;
    }

    static updateProblemList(problem) {
        const row = this.problemsTableBody.insertRow(0);
        row.insertCell(0).textContent = problem.expression;
        row.insertCell(1).textContent = problem.rightAnswer;
        const userAnswerCell = row.insertCell(2);
        userAnswerCell.textContent = problem.userAnswer;
        userAnswerCell.style.color = problem.isSolved ? "green" : "red";

        if (this.problemsTableBody.rows.length > 5) {
            this.problemsTableBody.deleteRow(5);
        }
    }

    static addCircle(problem) {
        const circleContainer = document.createElement("div");
        circleContainer.className = "circle-container";

        const circle = document.createElement("div");
        circle.className = "circle " + (problem.isSolved ? "green" : "red");

        const timeText = document.createElement("div");
        timeText.className = "time-taken";
        timeText.textContent = `${problem.timeTaken}s`;

        circleContainer.appendChild(circle);
        circleContainer.appendChild(timeText);
        this.circlesContainer.appendChild(circleContainer);
    }

    static showProblem(expression) {
        this.problemElement.textContent = expression;
    }

    static showFeedback(message, color) {
        this.feedbackElement.textContent = message;
        this.feedbackElement.style.color = color;
    }
}

// Initialize UI elements
UI.initElements();

// Initialize challenge data
const challenge = new Challenge(challengeData);
let currentProblem = challenge.unattemptedProblems.shift();
UI.showProblem(currentProblem.expression);
challenge.updateStats();


addInitialRowsToTable();
function addInitialRowsToTable() {
    for (let i = 0; i < 5; i++) {
        const row = UI.problemsTableBody.insertRow();
        for (let j = 0; j < 3; j++) {
            row.insertCell();
        }
    }
}

const countdown = setInterval(() => {
    UI.timerElement.textContent = parseInt(UI.timerElement.textContent) - 1;
    if (parseInt(UI.timerElement.textContent) <= 0) {
        clearInterval(countdown);
        challenge.sendStatsToServer();
    }
}, 1000);

UI.userAnswerElement.addEventListener("input", function() {
    const userAnswer = parseFloat(UI.userAnswerElement.value) || 0;

    if (UI.userAnswerElement.value.length >= currentProblem.rightAnswer.toString().length) {
        const timeTaken = challenge.recordTimeTaken();
        const correct = userAnswer == currentProblem.rightAnswer;

        currentProblem.userAnswer = userAnswer;
        currentProblem.timeTaken = timeTaken;
        currentProblem.isSolved = correct;

        if (correct) {
            challenge.solvedProblems++;
        } else {
            challenge.misses++;
        }

        challenge.updateProblemList(currentProblem);
        challenge.addCircle(currentProblem);
        challenge.updateStats();

        if (challenge.unattemptedProblems.length > 0) {
            currentProblem = challenge.unattemptedProblems.shift();
            UI.showProblem(currentProblem.expression);
        } else {
            challenge.sendStatsToServer();
        }

        UI.userAnswerElement.value = "";
        UI.showFeedback(correct ? "Correct!" : "Incorrect, please try again.", correct ? "green" : "red");
        setTimeout(() => UI.showFeedback("", ""), 2000);
    }
});
