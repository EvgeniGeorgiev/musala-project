Feature: Musala Tests


#Design your framework to support two browsers – chrome and firefox. Make the browser selection available from a configuration file.
#Store the base URL (http://www.musala.com/) in the configuration file
#Add a possibility the tests below to be executed in parallel simultaneously
#For Test Case 1 – prepare a test data file in a format of your choice, the file must contain 5 sets of invalid e-mail addresses. Implement the test to run 5 times with each e-mail address.
#Provide a report for the test runs 
#Add a README file

######

Scenario Outline: Verify invalid email address validation on Contact Us page

Given the user is on the landing page
When the user goes to Contact Us from the landing page
And the user populates the Contact Us dialog with wrong email data
And the user clicks the Send button in the Contact Us dialog
Then an error message '<Error Message>' appears in the Contact Us dialog

    Examples:
    |Error Message| 
    |The e-mail address entered is invalid.| 



Scenario Outline: Verify Leadership section and company Facebook page link

Given the user is on the landing page
When the user selects 'Company' section in the top navigation
Then the user verifies 'https://www.musala.com/company/' is the expected URL
Then the user verifies there is a Leadership section
When the user clicks Facebook link from the footer
Then the user verifies 'https://www.facebook.com/MusalaSoft?fref=ts' is the expected URL
Then the Musala Soft profile picture appears on the Facebook page



Scenario Outline: Verify Leadership section and company Facebook page link3333

Given the user is on the landing page
When the user selects 'Careers' section in the top navigation
When the user clicks ‘Check our open positions’ button
Then the user verifies 'https://www.musala.com/careers/join-us/' is the expected URL
#When the user selects ‘Anywhere’ in the Location Filter on Join Us page
#When the user selects 'Experienced Automation QA Engineer' position from the list on Join Us page
#???Then the user verifies there is a Leadership section
#Then ‘Apply’ button is present on the Job page
#When the user clicks ‘Apply’ button on the Job page


###ORIGINAL###TEST###BELOW###
#Visit http://www.musala.com/
#Navigate to Careers menu (from the top)
#Click ‘Check our open positions’ button
#Verify that  ‘Join Us’ page is opened (can verify that URL is correct: http://www.musala.com/careers/join-us/
#From the dropdown ‘Select location’ select ‘Anywhere’
#Choose open position by name (e.g., Experienced Automation QA Engineer)
#Verify that 4 main sections are shown: General Description, Requirements, Responsibilities, What we offer
#Verify that ‘Apply’ button is present at the bottom
#Click ‘Apply’ button
#Prepare a few sets of negative data (e.g., leave required field(s) empty, enter e-mail with invalid format etc.)
#Upload a CV document, and click ‘Send’ button
#Verify shown error messages (e.g., The field is required, The e-mail address entered is invalid etc.)
