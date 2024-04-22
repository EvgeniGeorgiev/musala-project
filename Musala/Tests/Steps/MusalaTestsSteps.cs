using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System.Data;
using TechTalk.SpecFlow;
using static System.Runtime.InteropServices.JavaScript.JSType;

[Binding]
public class MusalaTestSteps
{
    private readonly LandingPageInteractions _landingPageInteractions;
    private readonly GlobalPageInteractions _globalPageInteractions;
    private readonly CompanyPageInteractions _companyPageInteractions;
    private readonly CareersPageInteractions _careersPageInteractions;

    public MusalaTestSteps(LandingPageInteractions landingPageInteractions, GlobalPageInteractions globalPageInteractions, CompanyPageInteractions companyPageInteractions, CareersPageInteractions careersPageInteractions)
    {
        _landingPageInteractions = landingPageInteractions;
        _globalPageInteractions = globalPageInteractions;
        _companyPageInteractions = companyPageInteractions;
        _careersPageInteractions = careersPageInteractions;
    }

    [Given(@"the user is on the landing page")]
    public void TheUserIsOnTheLandingPage()
    {
        string landingPageUrl = ConfigurationSettings.GetBaseUrl();
        _globalPageInteractions.NavigateToPage("http://www.musala.com/");
        _globalPageInteractions.AcceptCookies();
    }

    [When(@"the user goes to Contact Us from the landing page")]
    public void TheUserGoesToContactUsFromTheLandingPage()
    {
        _landingPageInteractions.ClickOnContactUs();
    }


    [When(@"the user populates the Contact Us dialog with wrong email data")]
    public void TheUserPopulatesTheContactUsDialogWithWrongEmailData()
    {
        _landingPageInteractions.PopulateContactUsDialogWithWrongEmailData();
    }

    [When(@"the user clicks the Send button in the Contact Us dialog")]
    public void TheUserClicksTheSendButtonInTheContactUsDialog()
    {
        _landingPageInteractions.ClickTheSendButtonInTheContactUsDialog();
        Thread.Sleep(5000);
    }

    [Then(@"an error message '(.*)' appears in the Contact Us dialog")]
    public void AnErrorMessageAppearsInTheContactUsDialog(string expectedErrorMessage)
    {
        string emailValidationErrorMessage = _landingPageInteractions.GetEmailErrorMessageFromTheContactUsDialog();
        string dialogValidationErrorMessage = _landingPageInteractions.GetDialogErrorMessageFromTheContactUsDialog();

        //ToDo: Make it as a config
        string someGeneralError = "One or more fields have an error. Please check and try again.";

        ClassicAssert.AreEqual(expectedErrorMessage, emailValidationErrorMessage, $"Expected error message '{expectedErrorMessage}' but got '{emailValidationErrorMessage}'.");
        ClassicAssert.AreEqual(someGeneralError, dialogValidationErrorMessage, $"Expected error message '{someGeneralError}' but got '{dialogValidationErrorMessage}'.");
    }

    [When(@"the user selects '(.*)' section in the top navigation")]
    public void UserSelectsSectionInTopNavigation(string section)
    {
        _globalPageInteractions.SelectSectionInTopNavigation(section);
    }

    [Then("the user verifies '(.*)' is the expected URL")]
    public void UserVerifiesExpectedURL(string expectedUrl)
    {
        string currentUrl = _globalPageInteractions.getCurrentURL();
        ClassicAssert.AreEqual(expectedUrl, currentUrl);
    }

    [Then("the user verifies there is a Leadership section")]
    public void UserVerifiesLeadershipSectionExists()
    {
        bool leadershipSectionExists = _companyPageInteractions.IsLeadershipSectionVisible();
        ClassicAssert.IsTrue(leadershipSectionExists, "Leadership section does not exist on the page");
    }

    [When("the user clicks Facebook link from the footer")]
    public void UserClicksFacebookLink()
    {
        _companyPageInteractions.ClickCompanyFacebookIcon();
    }

    [Then("the Musala Soft profile picture appears on the Facebook page")]
    public void ProfilePictureAppearsOnFacebookPage()
    {
        bool facebookProfilePictureExists = _companyPageInteractions.IsFacebookProfilePictureVisible();
        ClassicAssert.IsTrue(facebookProfilePictureExists, "Facebook Main Profile Picture does not exist on the page. ");
    }

    [When("the user clicks ‘Check our open positions’ button")]
    public void TheUserClicksCheckOurOpenPositionsCTA()
    {
        _careersPageInteractions.ClickCheckOurOpenPositionsCTA();
    }

    [When("the user selects '(.*)' in the Location Filter on Join Us page")]
    public void TheUserSelectsOptionInLocationFilter(string option)
    {
        _careersPageInteractions.SelectOptionInLocationFilter(option);
    }

    [When("the user selects '(.*)' position from the list on Join Us page")]
    public void TheUserSelectsPosition(string option)
    {
        _careersPageInteractions.SelectPositionFromCareersList(option);
    }

    [Then("Apply CTA is present on the Job page")]
    public void ApplyCTAIsPresentOnJobPage()
    {
        bool isApplyCTAPresent = _careersPageInteractions.IsApplyButtonIsPresentOnJobPage();
        ClassicAssert.IsTrue(isApplyCTAPresent, "Apply job CTA is not present on the page. ");
    }

    [When("the user clicks Apply CTA on the Job page")]
    public void TheUserClicksApplyCTAOnJobPage()
    {
        _careersPageInteractions.ClickApplyCTAOnJobPage();
    }

    [When("the user populates Apply For form with '(.*)'")]
    public void TheUserPopulatesApplyForFormWithData(string data)
    {
        _careersPageInteractions.PopulateApplyForm(data);
    }

    [When("the user clicks Send CTA in the Apply Form")]
    public void WhenUserClicksSendCTAinApplyForm()
    {
        _careersPageInteractions.SendApplyForm();
    }

    [Then("an error messages for '(.*)' appear in the dialog")]
    public void AnErrorMessagesAppearInDialog(string messages)
    {
        var values = messages.Split(',')
                            .Select(part => part.Split(':'))
                            .ToDictionary(split => split[0].Trim(), split => split.Length > 1 ? split[1].Trim() : null);

        if (values.ContainsKey("Name"))
        {
            ClassicAssert.AreEqual(values["Name"], _careersPageInteractions.GetNameErrorMessageFromApplyDialog());
        }
        if (values.ContainsKey("Email"))
        {
            ClassicAssert.AreEqual(values["Email"], _careersPageInteractions.GetEmailErrorMessageFromApplyDialog());
        }
        if (values.ContainsKey("Phone"))
        {
            ClassicAssert.AreEqual(values["Phone"], _careersPageInteractions.GetPhoneErrorMessageFromApplyDialog());
        }

        if (values.ContainsKey("GeneralMessage"))
        {
            ClassicAssert.AreEqual(values["GeneralMessage"], _careersPageInteractions.GetGeneralErrorMessageFromApplyDialog());
        }
    }

    [Then(@"the user verifies there is a '(.*)' section shown in the Job page")]
    public void ThenUserVerifiesSectionsShownInJobPage(string sections)
    {
        List<string> actualSections = _careersPageInteractions.GetShowSectionsInJobPage();

        List<string> expectedSections = new List<string>(sections.Split(','));
        foreach (string section in expectedSections)
        {
            ClassicAssert.Contains(section, actualSections);
        }
    }

    [Then("Print all available positions for '(.*)' location")]
    public void PrintAllAvailablePositionsByCity(string location)
    {
        _careersPageInteractions.SelectOptionInLocationFilter(location);

        _careersPageInteractions.PrintAllJobsForCity(location);
    }
}