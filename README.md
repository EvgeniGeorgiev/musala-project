# Musala Soft Automation Framework


## Features

- **Browser Support:** The framework supports two browsers, Chrome and Firefox. Browser selection can be configured from a configuration file.
- **Base URL Configuration:** The base URL (http://www.musala.com/) is stored in the configuration file.
- **Parallel Execution:** Tests can be executed in parallel simultaneously for faster execution.
- **Reporting:** The framework provides a detailed report for test runs.
- **Additional Features:** Add any other useful features you've implemented here.

## Test Cases Implemented

### Test Case 1

- Visit http://www.musala.com/
- Scroll down and go to 'Contact Us'
- Fill all required fields except email
- Enter a string with a wrong email format under the email field (e.g., test@test)
- Click 'Send' button
- Verify that the error message 'The e-mail address entered is invalid.' appears

### Test Case 2

- Visit http://www.musala.com/
- Click 'Company' tab from the top
- Verify that the correct URL (http://www.musala.com/company/) loads
- Verify the presence of the 'Leadership' section
- Click the Facebook link from the footer
- Verify that the correct URL (https://www.facebook.com/MusalaSoft?fref=ts) loads
- Verify if the Musala Soft profile picture appears on the new page

### Test Case 3

- Visit http://www.musala.com/
- Navigate to Careers menu (from the top)
- Click 'Check our open positions' button
- Verify that the 'Join Us' page is opened (URL: http://www.musala.com/careers/join-us/)
- From the dropdown 'Select location', select 'Anywhere'
- Choose an open position by name (e.g., Experienced Automation QA Engineer)
- Verify that 4 main sections are shown: General Description, Requirements, Responsibilities, What we offer
- Verify that the 'Apply' button is present at the bottom
- Click 'Apply' button
- Prepare a few sets of negative data (e.g., leave required field(s) empty, enter email with invalid format, etc.)
- Upload a CV document and click 'Send' button
- Verify shown error messages

### Test Case 4

- Visit http://www.musala.com/
- Go to Careers
- Click 'Check our open positions' button
- Filter the available positions by available cities in the dropdown 'Select location' (Sofia and Skopje)
- Get the open positions by city
- Print in the console the list with available positions by city

## Setup and Usage

- In Config.json use "Browser": "chrome" or "Browser": "firefox" to select a browser.
- In Config.json change "BaseUrl" to config the default url.
- Features with tag @parallel will run in parallel.

## Dependencies

---

## Contributors

Evgeni Georgiev
