# MathXGame Project

## Project Overview

This project is a web application for editing user account details. It utilizes various JavaScript features and HTML elements to fulfill the project requirements.

## Project Requirements

### 1. Functions and Loops
- **Functions**: [validateForm()](#validateform-function)
- **Loops**: Used inside `validateForm()` for validation
    - Code: [validateForm() function - Lines 72-124](#validateform-function)

### 2. Hoisting and Strict Mode
- **Strict Mode**: Enabled in the script
    - Code: [Strict Mode - Line 128](#strict-mode)
- **Hoisting**: Demonstrated by function declarations
    - Code: [validateForm() function - Lines 72-124](#validateform-function)

### 3. Events
- **onSubmit**: Form submission
    - Code: [Form Submission Event - Line 66](#form-submission-event)
- **onFocus**: Input focus
    - Code: [onFocusFunction() - Lines 156-158](#onfocusfunction)
- **onBlur**: Input blur
    - Code: [onBlurFunction() - Lines 160-162](#onblurfunction)
- **onClick**: Back button
    - Code: [Back Button Event - Line 64](#back-button-event)

### 4. Eval(), Number(), isNaN(), preventDefault(), onFocus(), onBlur() Functions
- **eval()**: 
    - Code: [Eval Usage - Add your specific line here](#eval-usage)
- **Number()**: 
    - Code: [Number Usage - Add your specific line here](#number-usage)
- **isNaN()**: 
    - Code: [isNaN() Usage - Line 104](#isnan-usage)
- **preventDefault()**: Prevent default form submission
    - Code: [preventDefault() - Line 73](#preventdefault)
- **onFocus()**: Change background color on focus
    - Code: [onFocusFunction() - Lines 156-158](#onfocusfunction)
- **onBlur()**: Revert background color on blur
    - Code: [onBlurFunction() - Lines 160-162](#onblurfunction)

### 5. String Methods (charAt, indexOf, …)
- **charAt()**: First character of username
    - Code: [charAt() - Line 166](#charat)
- **indexOf()**: Finding '@' in email
    - Code: [indexOf() - Line 171](#indexof)

### 6. Array and Its Methods (find, filter, …)
- **Array Methods**: Usage examples
    - Code: [Array Methods - Add your specific lines here](#array-methods)

### 7. Date Object and Its Functions
- **Date.parse()**: Validate date of birth
    - Code: [Date.parse() - Line 103](#date-parse)

### 8. RegExpression (Input Validation)
- **RegEx**: Email validation
    - Code: [Email Regex Validation - Line 98](#email-regex-validation)

### 9. setInterval and setTimeout Functions
- **setInterval**: Log message every 5 seconds
    - Code: [setInterval - Line 181](#setinterval)
- **setTimeout**: Log message after 10 seconds
    - Code: [setTimeout - Line 184](#settimeout)

### 10. addEventListener Function
- **addEventListener**: Input events
    - Code: [addEventListener - Lines 165, 170](#addeventlistener)

### 11. querySelector Function
- **querySelector**: Usage example
    - Code: [querySelector - Add your specific line here](#queryselector)

### 12. Images and Change Its Properties Using JS
- **Change Image Properties**: Display status images
    - Code: [Image Manipulation - Lines 123-124](#image-manipulation)

### 13. onSubmit Event
- **onSubmit**: Validate form on submit
    - Code: [Form onSubmit - Line 66](#form-onsubmit)

## Detailed Code References

### validateForm Function
```javascript
function validateForm(event) {
    event.preventDefault();
    let isValid = true;
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    const email = document.getElementById('email').value;
    const firstName = document.getElementById('firstName').value;
    const lastName = document.getElementById('lastName').value;
    const dateOfBirth = document.getElementById('dateOfBirth').value;

    // Username validation
    if (username.length < 5) {
        document.getElementById('usernameError').innerText = 'Username must be at least 5 characters long.';
        isValid = false;
    } else {
        document.getElementById('usernameError').innerText = '';
    }

    // Password validation
    if (password.length < 8) {
        document.getElementById('passwordError').innerText = 'Password must be at least 8 characters long.';
        isValid = false;
    } else {
        document.getElementById('passwordError').innerText = '';
    }

    // Email validation using RegEx
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
        document.getElementById('emailError').innerText = 'Invalid email address.';
        isValid = false;
    } else {
        document.getElementById('emailError').innerText = '';
    }

    // Date of birth validation
    if (isNaN(Date.parse(dateOfBirth))) {
        document.getElementById('dateOfBirthError').innerText = 'Invalid date of birth.';
        isValid = false;
    } else {
        document.getElementById('dateOfBirthError').innerText = '';
    }

    if (isValid) {
        // Simulate form submission success
        document.getElementById('statusImage').style.display = 'block';
        document.getElementById('statusImage').src = '@Url.Content("~/images/success.png")';
        setTimeout(() => {
            document.getElementById('editAccountForm').submit();
        }, 2000);
    } else {
        document.getElementById('statusImage').style.display = 'block';
        document.getElementById('statusImage').src = '@Url.Content("~/images/error.png")';
        setTimeout(() => {
            document.getElementById('statusImage').style.display = 'none';
        }, 2000);
    }
}
@