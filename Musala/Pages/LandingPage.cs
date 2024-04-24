using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

public class LandingPage : GlobalPage
{
    private readonly By ContactUsCTA = By.CssSelector("[data-alt='Contact us']");
    private readonly By ContactUsFields = By.CssSelector("[class*='wpcf7-form']>p");
    private readonly By ContactUsSubmit = By.CssSelector("[class*='wpcf7-submit']");
    private readonly By EmailValidationMessage = By.CssSelector("[data-name='your-email'] .wpcf7-not-valid-tip");
    private readonly By DialogValidationMessage = By.CssSelector(".wpcf7-response-output");


    internal void ClickOnContactUs()
    {
        Actions actions = new Actions(webDriver);
        actions.ScrollByAmount(0, 300).Perform();

        webDriver.FindElement(ContactUsCTA).Click();
    }

    internal void ClickTheSendButtonInTheContactUsDialog()
    {
        webDriver.FindElement(ContactUsSubmit).Click();
    }

    internal string GetEmailErrorMessageFromTheContactUsDialog()
    {
        return webDriver.FindElement(EmailValidationMessage).GetAttribute("textContent");
    }

    internal string GetDialogErrorMessageFromTheContactUsDialog()
    {
        return webDriver.FindElement(DialogValidationMessage).GetAttribute("textContent");
    }
}