Feature: Musala Tests


#For Test Case 1 – prepare a test data file in a format of your choice, the file must contain 5 sets of invalid e-mail addresses. Implement the test to run 5 times with each e-mail address.


######
Scenario Outline: Verify invalid email address validation on Contact Us page

Given the user is on the landing page
When the user goes to Contact Us from the landing page
And the user populates the Contact Us dialog with wrong email data
And the user clicks the Send button in the Contact Us dialog
Then an error messages for '<Error Message>' appear in the dialog

    Examples:
    |Error Message| 
    |Email:The e-mail address entered is invalid. | 


Scenario Outline: Verify Leadership section and company Facebook page link

Given the user is on the landing page
When the user selects 'Company' section in the top navigation
Then the user verifies 'https://www.musala.com/company/' is the expected URL
Then the user verifies there is a Leadership section
When the user clicks Facebook link from the footer
Then the user verifies 'https://www.facebook.com/MusalaSoft?fref=ts' is the expected URL
Then the Musala Soft profile picture appears on the Facebook page


Scenario Outline: Verify validation error messages on Join Us dialog

Given the user is on the landing page
When the user selects 'Careers' section in the top navigation
When the user clicks ‘Check our open positions’ button
Then the user verifies 'https://www.musala.com/careers/join-us/' is the expected URL
When the user selects 'Anywhere' in the Location Filter on Join Us page
When the user selects 'Automation QA Engineer' position from the list on Join Us page
Then the user verifies there is a 'General description,Requirements,Responsibilities,What we offer' section shown in the Job page
Then Apply CTA is present on the Job page
When the user clicks Apply CTA on the Job page
When the user populates Apply For form with '<Data>'
Then an error messages for '<Message>' appear in the dialog
When the user clicks Send CTA in the Apply Form
Then an error messages for '<GeneralMessage>' appear in the dialog

    Examples: 
    | Data                                      | Message                                                                             | GeneralMessage                                                |
    | asd,asd@asd,123123,..\\..\\..\\CV.doc,asd | Email:The e-mail address entered is invalid.                                        | One or more fields have an error. Please check and try again. |
    | Name,Email,Mobile,,                       | Email:The e-mail address entered is invalid.,Phone:The telephone number is invalid. | One or more fields have an error. Please check and try again. |
    | ,Email@abv.bg,,,Hello                     | Name:The field is required.,Phone:The field is required.                            | One or more fields have an error. Please check and try again. |


@parallel
Scenario Outline: Return list of available positions by city

Given the user is on the landing page
When the user selects 'Careers' section in the top navigation
When the user clicks ‘Check our open positions’ button
Then Print all available positions for 'Bulgaria' location
Then Print all available positions for 'Egypt' location