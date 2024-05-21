# Project Requirements Demo

This project demonstrates various JavaScript functionalities as per the given requirements. Below is a detailed breakdown of each requirement, including where it has been implemented in the project.

## Table of Contents
1. [Functions and Loops](#functions-and-loops)
2. [Hoisting and Strict Mode](#hoisting-and-strict-mode)
3. [Events](#events)
4. [Specific Functions](#specific-functions)
5. [String Methods](#string-methods)
6. [Array Methods](#array-methods)
7. [Date Object](#date-object)
8. [Regular Expressions](#regular-expressions)
9. [setInterval and setTimeout](#setinterval-and-settimeout)
10. [addEventListener](#addeventlistener)
11. [querySelector](#queryselector)
12. [Image Manipulation](#image-manipulation)
13. [onSubmit Event](#onsubmit-event)

## Functions and Loops
- **Location**: [_Layout.cshtml, Line 30-35](/../Views/Shared/_Layout.cshtml#L30-L35)
- **Description**: A function `displayNumbers` that uses a loop to log numbers from 0 to 4.

## Hoisting and Strict Mode
- **Location**: [Login.cshtml, Line 15-20](Account/Login.cshtml#L15-L20)
- **Description**: Demonstrates function hoisting and the use of 'use strict' mode at the top of the file.

## Events
- **Location**: [Register.cshtml, Line 22-34](Account/Register.cshtml#L22-L34)
- **Description**: Various event listeners are added for `submit`, `focus`, `blur`, and `click` events.

## Specific Functions
- **Location**: [Settings.cshtml, Line 40-60](Account/Settings.cshtml#L40-L60)
- **Description**: Uses `preventDefault()`, `Number()`, `isNaN()`, `eval()`, `onFocus()`, and `onblur()` within form validation and event handling functions.

## String Methods
- **Location**: [FinishedChallenge.cshtml, Line 15-20](Challenges/FinishedChallenge.cshtml#L15-L20)
- **Description**: Uses `indexOf` to check if the username contains spaces during form validation.

## Array Methods
- **Location**: [UserStatistics.cshtml, Line 25-35](Home/UserStatistics.cshtml#L25-L35)
- **Description**: Uses array methods like `find` and `filter` to process user statistics data.

## Date Object
- **Location**: [Index.cshtml, Line 40-45](Home/Index.cshtml#L40-L45)
- **Description**: Uses the `Date` object to display the current time and updates it every second using `setInterval`.

## Regular Expressions
- **Location**: [Privacy.cshtml, Line 33-37](Home/Privacy.cshtml#L33-L37)
- **Description**: Validates the email format using a regular expression during form validation.

## setInterval and setTimeout
- **Location**: [ViewChallenge.cshtml, Line 22-27](Challenges/ViewChallenge.cshtml#L22-L27)
- **Description**: Uses `setInterval` to update the current time display every second.

## addEventListener
- **Location**: [MultipleChoiceChallenge.cshtml, Line 28-40](Challenges/MultipleChoiceChallenge.cshtml#L28-L40)
- **Description**: Adds various event listeners using `addEventListener`.

## querySelector
- **Location**: [ErrorMessage.cshtml, Line 18-22](Challenges/ErrorMessage.cshtml#L18-L22)
- **Description**: Uses `querySelector` to select elements for event handling and validation.

## Image Manipulation
- **Location**: [KeyboardInputChallenge.cshtml, Line 44-48](Challenges/KeyboardInputChallenge.cshtml#L44-L48)
- **Description**: Changes the source of an image when a button is clicked.

## onSubmit Event
- **Location**: [Index.cshtml, Line 18-20](Challenges/Index.cshtml#L18-L20)
- **Description**: Handles the `submit` event of the form to validate input data and prevent form submission if validation fails.

## How to Run
1. Clone the repository.
2. Open `index.html` in a web browser.
3. Interact with the form, buttons, and other elements to see the functionalities in action.

## Author
- [Your Name]

Feel free to explore the code and see how each requirement is implemented. If you have any questions or suggestions, please open an issue or contact me directly.

