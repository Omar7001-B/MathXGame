# MathXGame

## Overview
MathXGame is an engaging and fast-paced math practice game designed to help users improve their arithmetic skills through various challenges. Users can register or log in to start practicing and select from a range of challenges that test different mathematical abilities.

## Features
- **User Authentication**: Register and log in to track your progress and challenge history.
- **Real-Time Feedback**: Instant validation of answers and automatic progression to the next question.
- **Detailed Statistics**: Comprehensive performance stats after each challenge.
- **Review System**: Options to review all problems, incorrect problems, or slow responses to enhance learning.

## Challenges
The game currently offers the following challenges:

- [x] **Keyboard Input Challenge**: Enter answers using keyboard input.
- [x] **Multiple Choice Challenge**: Select answers from multiple choices.
- [ ] **Missing Operator Challenge**: Identify missing operators in equations.
- [ ] **Word Problem Challenge**: Solve word problems by typing answers in words.
- [ ] **Math Memory Challenge**: Memorize and solve math problems.
- [ ] **Number Placement Challenge**: Place numbers correctly in equations.
- [ ] **Comparison Challenge**: Compare two expressions with <, >, or =.
- [ ] **Solve for X Challenge**: Solve for X in algebraic equations.
- [ ] **True/False Challenge**: Determine if math statements are true or false.
- [ ] **Number Combination Challenge**: Combine numbers to reach a target sum.

## Database Structure
### User
- **Id**: Unique identifier
- **Username**: User's login name
- **Password**: User's password
- **Email**: User's email
- **FirstName**: User's first name (optional)
- **LastName**: User's last name (optional)
- **DateOfBirth**: User's date of birth (optional)
- **Challenges**: List of challenges completed by the user
- **Problems**: List of problems encountered by the user

### Challenge
- **ChallengeId**: Unique identifier
- **UserId**: Reference to the user
- **SelectedChallenge**: Type of challenge
- **TotalProblems**: Total number of problems in the challenge
- **TimerInSeconds**: Time limit for the challenge
- **MinNumber**: Minimum number in problems
- **MaxNumber**: Maximum number in problems
- **Addition**: Includes addition problems
- **Subtraction**: Includes subtraction problems
- **Multiplication**: Includes multiplication problems
- **Division**: Includes division problems
- **SolvedProblems**: Number of correctly solved problems
- **Misses**: Number of missed problems
- **Speed**: Average time taken per problem
- **Accuracy**: Accuracy percentage
- **Score**: Overall challenge score
- **StartTime**: Challenge start time
- **FinishTime**: Challenge finish time

### Problem
- **ProblemId**: Unique identifier
- **ChallengeId**: Reference to the challenge
- **UserId**: Reference to the user
- **Expression**: Math problem expression
- **RightAnswer**: Correct answer
- **UserAnswer**: User's answer
- **IsSolved**: Boolean indicating if the problem was solved correctly
- **TimeTaken**: Time taken to solve the problem

## Key Features
- **Speed**: Automatically validates correct answers and moves to the next question.
- **Immediate Feedback**: Shows correct answer and history of the last 5 problems for incorrect answers.
- **Timing**: Displays the time taken for each answer.
- **Quick Selection**: Choose multiple-choice answers by pressing their number for faster gameplay.

## Todo
- [ ] Implement the remaining challenges.
- [ ] Add a leaderboard for challenges.
- [ ] Make the game more interactive with animations and sound effects.
- [ ] Add more customization options for challenges.
- [ ] Add more challenges.
- [ ] Add more statistics.	
- [ ] Add a multiplayer mode.

## Note Necessary Packages
```bash
dotnet add package Microsoft.EntityFrameworkCore 
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

## Demo Video


https://github.com/Omar7001-B/MathXGame/assets/115028809/6afdae92-311f-4461-8edf-ab9105be0e04


