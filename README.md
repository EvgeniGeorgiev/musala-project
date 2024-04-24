## Automation Test Assignment

[[_TOC_]]

---

### Introduction

You are given an assignment to provide automated tests for Musala Soft website http://www.musala.com/.
Design a test automation framework in a language of your choice.

---

### General requirements

1. Design your framework to support two browsers – Chrome and Firefox. Make the browser selection available from a configuration file. 
1. Store the base URL (http://www.musala.com/) in the configuration file.
1. Add a possibility the tests below to be executed in parallel simultaneously.
1. For "Test Case 1" – prepare a test data file in a format of your choice, the file must contain 5 sets of invalid e-mail addresses. Implement the test to run 5 times with each e-mail address.
1. Provide a report for the test runs.
1. Add a README file.
1. If you can think of other useful features – feel free to include them as well!

---

### Required test cases

#### Test Case 1 

1. Visit http://www.musala.com/
1. Scroll down and go to ‘Contact Us’
1. Fill all required fields except email
1. Under email field enter string with wrong email format (e.g., test@test)
1. Click ‘Send’ button
1. Verify that error message ‘The e-mail address entered is invalid.’ appears

---

#### Test Case 2

1. Visit http://www.musala.com/
1. Click ‘Company’ tap from the top 3. Verify that the correct URL (http://www.musala.com/company/) loads
1. Verify that there is ‘Leadership’ section
1. Click the Facebook link from the footer 6. Verify that the correct URL (https://www.facebook.com/MusalaSoft?fref=ts) loads and verify if the Musala Soft profile picture appears on the new page

---

#### Test Case 3 

1. Visit http://www.musala.com/
1. Navigate to Careers menu (from the top)
1. Click ‘Check our open positions’ button
1. Verify that ‘Join Us’ page is opened (can verify that URL is correct: http://www.musala.com/careers/join-us/
1. From the dropdown ‘Select location’ select ‘Anywhere’
1. Choose open position by name (e.g., Experienced Automation QA Engineer)
1. Verify that 4 main sections are shown: General Description, Requirements, Responsibilities, What we offer
1. Verify that ‘Apply’ button is present at the bottom
1. Click ‘Apply’ button
1. Prepare a few sets of negative data (e.g., leave required field(s) empty, enter e-mail with invalid format etc.)
1. Upload a CV document, and click ‘Send’ button
1. Verify shown error messages (e.g., The field is required, The e-mail address entered is invalid etc.)

---

#### Test Case 4 

1. Visit http://www.musala.com/
1. Go to Careers
1. Click ‘Check our open positions’ button
1. Filter the available positions by available cities in the dropdown ‘Select location’ (Sofia and Skopje)
1. Get the open positions by city
1. Print in the console the list with available positions by city as shown below

**Example:**
```
Sofia
Position: Database Administrator
More info: http://www.musala.com/job/database-administrator/
Position: OS and Application Administrator
More info: http://www.musala.com/job/os-and-application-administrator/
Position: ........... 
More info: ........... 

Skopje
Position: ........... 
More info: ........... 
........... 
```

## Setup and Usage

- In Config.json use "Browser": "chrome" or "Browser": "firefox" to select a browser.
- In Config.json change "BaseUrl" to config the default url.
- Features with tag @parallel will run in parallel.

## Dependencies

---

## Contributors

Evgeni Georgiev
