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
- **Location**: [MultipleChoiceChallenge.js, Line 1-205](/Views/Shared/_Layout.cshtml#L30-L35)
  - **Description**: Defines functions and methods including `print`, `initializeProblems`, and `addInitialRowsToTable`.

## Hoisting and Strict Mode
- **Location**: [MultipleChoiceChallenge.js, Line 1, 174](\wwwroot\js\MultipleChoiceChallenge.js#L1), [Settings.cshtml, Line 9](\Views\Account\Settings.cshtml#L9)
  - **Description**: Demonstrates hoisting with the `print` function and uses strict mode in various functions.

## Events
- **Location**: [MultipleChoiceChallenge.js, Line 238, 210, 174, 259](\wwwroot\js\MultipleChoiceChallenge.js#L238-L259)
  - **Description**: Adds event listeners for `input`, `setInterval`, `submit`, and `setTimeout`.

## Specific Functions
- **Location**: [MultipleChoiceChallenge.js, Line 77, 142, 174, 199, 238](\wwwroot\js\MultipleChoiceChallenge.js#L77-L199), [Settings.cshtml, Line 36](\Views\Account\Settings.cshtml#L36)
  - **Description**: Uses functions like `eval`, `Number()`, `isNaN()`, `preventDefault()`, and defines a custom `goBack` function.

## String Methods
- **Location**: Not explicitly used.
  - **Description**: Ensure to implement string methods like `indexOf` in future validations.

## Array Methods
- **Location**: [MultipleChoiceChallenge.js, Line 23, 35](\wwwroot\js\MultipleChoiceChallenge.js#L23-L35)
  - **Description**: Utilizes `Array.isArray` and `map` to handle arrays.

## Date Object
- **Location**: [MultipleChoiceChallenge.js, Line 15, 86, 123](\wwwroot\js\MultipleChoiceChallenge.js#L15-L123)
  - **Description**: Uses the `Date` object for time tracking and calculations.

## Regular Expressions
- **Location**: Not explicitly used.
  - **Description**: Ensure to implement regular expressions for input validation in future implementations.

## setInterval and setTimeout
- **Location**: [MultipleChoiceChallenge.js, Line 212, 259](\wwwroot\js\MultipleChoiceChallenge.js#L212-L259)
  - **Description**: Uses `setInterval` for timer updates and `setTimeout` for delayed actions.

## addEventListener
- **Location**: [MultipleChoiceChallenge.js, Line 238, 259](\wwwroot\js\MultipleChoiceChallenge.js#L238-L259)
  - **Description**: Adds event listeners for various interactions.

## querySelector
- **Location**: Not explicitly used.
  - **Description**: Ensure to implement `querySelector` for selecting DOM elements in future implementations.

## Image Manipulation
- **Location**: Not explicitly used.
  - **Description**: Ensure to implement image manipulation in future features.

## onSubmit Event
- **Location**: [MultipleChoiceChallenge.js, Line 174](\wwwroot\js\MultipleChoiceChallenge.js#L174)
  - **Description**: Handles form submission event in `sendStatsToServer`.
