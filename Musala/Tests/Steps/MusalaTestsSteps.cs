using NUnit.Framework.Legacy;
using TechTalk.SpecFlow;

[Binding]
public class MusalaTestSteps
{
    private readonly LandingPageInteractions _landingPageInteractions;
    private readonly GlobalPageInteractions _globalPageInteractions;
    private readonly CompanyPageInteractions _companyPageInteractions;

    public MusalaTestSteps(LandingPageInteractions landingPageInteractions, GlobalPageInteractions globalPageInteractions, CompanyPageInteractions companyPageInteractions)
    {
        _landingPageInteractions = landingPageInteractions;
        _globalPageInteractions = globalPageInteractions;
        _companyPageInteractions = companyPageInteractions;
    }

    [Given(@"the user is on the landing page")]
    public void TheUserIsOnTheLandingPage()
    {
        string landingPageUrl = ConfigurationSettings.GetBaseUrl();
        _globalPageInteractions.NavigateToPage("http://www.musala.com/");
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
        ClassicAssert.IsTrue(facebookProfilePictureExists, "Facebook Main Profile Picture does not exist on the page");
    }

    [When("the user clicks ‘Check our open positions’ button")]
    public void TheUserClicksCheckOurOpenPositionsCTA()
    {

    }

}