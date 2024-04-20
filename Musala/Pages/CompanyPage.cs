using OpenQA.Selenium;

public class CompanyPage : GlobalPage
{
    private readonly By LeadershipSection = By.CssSelector("section.company-members");
    private readonly By FacebookIcon = By.CssSelector(".musala-icon-facebook");
    private readonly By FacebookProfilePicture = By.CssSelector("svg[aria-label='Musala Soft']");

    internal bool IsLeadershipSectionVisible()
    {
        return IsElementVisible(LeadershipSection);
    }

    internal bool IsFacebookProfilePictureVisible()
    {
        return IsElementVisible(FacebookProfilePicture);
    }

    internal void ClickCompanyFacebookIcon()
    {
        webDriver.FindElement(FacebookIcon).Click();
    }

}