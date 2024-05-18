# MathXGame

 # MathXGame
 ## Description
 MathXGame is a simple math game that allows users to practice their math skills through a series of challenges. The game presents users with math problems to solve within a specified time limit and provides feedback on their performance. Users can customize the difficulty level, number range, timer settings, operation selection, number of questions, scoring system, and feedback options to tailor the game to their preferences. MathXGame also includes a feature that allows users to save their preferred challenge settings for future use.

 ## Features
 - Challenge Configuration
	- Number Range: Users can specify the range of numbers used in the challenge.
	- Timer Settings: Users can customize the time limit for completing the challenge.
	- Operation Selection: Users can select the types of mathematical operations included in the challenge.
	- Number of Questions: Users can specify the number of questions they want to attempt in the challenge.

# Challenges TODO:
- [x] Keyboard Input Challenge
- [ ] Multiple Choice Challenge
- [ ] Missing Operator Challenge
- [ ] Word Problem Challenge
- [ ] Math Memory Challenge
- [ ] Inequality Expression Challenge
- [ ] Variable Equation Challenge
- [ ] Number Placement Challenge (Simple Version)
- [ ] Number Placement Challenge (Advanced Version)
- [ ] True/False Expression Challenge
- [ ] Sum Combination Challenge
- [ ] 12-Question Math Challenge

# Database
## Users Table
| Column    | Data Type | Description                          |
|-----------|-----------|--------------------------------------|
| user_id   | INT       | Primary Key, unique identifier for each user |
| username  | VARCHAR   | Username of the user                 |
| email     | VARCHAR   | Email of the user                    |
| password  | VARCHAR   | Password (hashed) of the user        |


## Challenges Table
| Column           | Data Type  | Description                                  |
|------------------|------------|----------------------------------------------|
| challenge_id     | INT        | Primary Key, unique identifier for each challenge |
| user_id          | INT        | Foreign Key, references Users(user_id)       |
| selected_challenge | VARCHAR  | Name or type of the challenge                |
| min_number       | INT        | Minimum number used in problems              |
| max_number       | INT        | Maximum number used in problems              |
| timer_in_seconds | INT        | Duration of the challenge in seconds         |
| addition         | BOOLEAN    | Indicates if addition problems are included  |
| subtraction      | BOOLEAN    | Indicates if subtraction problems are included |
| multiplication   | BOOLEAN    | Indicates if multiplication problems are included |
| division         | BOOLEAN    | Indicates if division problems are included  |
| total_problems   | INT        | Total number of problems in the challenge    |
| solved_problems  | INT        | Number of correctly solved problems          |
| misses           | INT        | Number of missed problems                    |
| speed            | DOUBLE     | Average speed of solving problems            |
| accuracy         | DOUBLE     | Accuracy percentage                          |
| start_time       | TIMESTAMP  | Timestamp of when the challenge started      |
| finish_time      | TIMESTAMP  | Timestamp of when the challenge ended        |


## Problems Table
| Column       | Data Type | Description                                  |
|--------------|-----------|----------------------------------------------|
| problem_id   | INT       | Primary Key, unique identifier for each problem |
| challenge_id | INT       | Foreign Key, references Challenges(challenge_id) |
| user_id      | INT       | Foreign Key, references Users(user_id)       |
| expression   | VARCHAR   | Math expression (e.g., "5 + 3")              |
| right_answer | VARCHAR   | Correct answer to the expression             |
| user_answer  | VARCHAR   | User’s answer to the problem                 |
| is_solved    | BOOLEAN   | Whether the problem was solved correctly     |
| time_taken   | INT       | Time taken by the user to solve the problem (in seconds) |





# Note Nessacry Packages
```bash
dotnet add package Microsoft.EntityFrameworkCore 
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```