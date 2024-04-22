using AngleSharp.Text;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;
using TechTalk.SpecFlow;

public class CareersPage : GlobalPage
{
    private readonly By CheckOurOpenPositionsCTA = By.CssSelector("[data-alt='Check our open positions']");
    private readonly By LocationFilter = By.CssSelector("#get_location");
    private readonly By LocationFilterOptions = By.CssSelector("#get_location option");
    private readonly By CardPositionsList = By.CssSelector(".card-jobsHot__title");
    private readonly By ApplyCTA = By.CssSelector(".btn-apply");
    private readonly By AcceptAdConcentCheckbox = By.CssSelector("input#adConsentChx");
    private readonly By SubmitApplyFormCTA = By.CssSelector("input.btn-cf-submit");
    private readonly By NameValidationMessage = By.CssSelector("[data-name='your-name'] .wpcf7-not-valid-tip");
    private readonly By EmailValidationMessage = By.CssSelector("[data-name='your-email'] .wpcf7-not-valid-tip");
    private readonly By PhoneValidationMessage = By.CssSelector("[data-name='mobile-number'] .wpcf7-not-valid-tip");
    private readonly By GeneralValidationMessage = By.CssSelector("div.wpcf7-response-output");

    internal void ClickApplyCTAOnJobPage()
    {
        //ToDo: Manage Consent element intercepts click when not on full screen.
        Actions actions = new Actions(webDriver);
        actions.ScrollByAmount(0, 500).Perform();
        webDriver.FindElement(ApplyCTA).Click();

        //Click(ApplyCTA);
    }

    internal void ClickCheckOurOpenPositionsCTA()
    {
        webDriver.FindElement(CheckOurOpenPositionsCTA).Click();
    }

    internal void ExpandLocationFilter()
    {
        Click(LocationFilter);
    }

    internal bool IsApplyButtonIsPresentOnJobPage()
    {
        return IsElementVisible(ApplyCTA);
    }

    internal void PopulateApplyForm(string data)
    {
        List<string> dataList = new List<string>(data.Split(','));

        for (int i = 0; i <= 4; i++)
        {
            string index = (i + 1).ToString();
            string cssSelector = $"[for*='cf-{index}']";
            IWebElement elementText = webDriver.FindElement(By.CssSelector(cssSelector));
            IWebElement element = webDriver.FindElement(By.CssSelector($"[id*='cf-{index}']"));
            if (elementText.Text == "Upload your CV")
            {
                element.SendKeys(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), dataList[i])));
            }
            else
            {
                element.SendKeys(dataList[i]);
            }
        }
    }

    internal void SelectOptionFromLocationFilter(string option)
    {
        ClickElementFromListByText(LocationFilterOptions, option);
    }

    internal void SelectPositionFromCareersList(string option)
    {
        ClickElementFromListByText(CardPositionsList, option);
    }

    internal void clickSendCTA()
    {
        Click(SubmitApplyFormCTA);
    }
    internal void AcceptAdConcent()
    {
        Click(AcceptAdConcentCheckbox);
    }

    internal string GetEmailErrorMessageFromApplyDialog()
    {
        return webDriver.FindElement(EmailValidationMessage).GetAttribute("textContent");
    }

    internal string GetNameErrorMessageFromApplyDialog()
    {
        return webDriver.FindElement(NameValidationMessage).GetAttribute("textContent");
    }

    internal string GetPhoneErrorMessageFromApplyDialog()
    {
        return webDriver.FindElement(PhoneValidationMessage).GetAttribute("textContent");
    }

    internal string GetGeneralErrorMessageFromApplyDialog()
    {
        var asd = webDriver.FindElement(GeneralValidationMessage).GetAttribute("textContent");
        return webDriver.FindElement(GeneralValidationMessage).GetAttribute("textContent");
    }

    internal List<string> GetShowSectionsInJobPage()
    {
        IReadOnlyCollection<IWebElement> sectionElements = webDriver.FindElements(By.CssSelector(".content-title"));
        List<string> sectionTexts = new List<string>();
        foreach (var element in sectionElements)
        {
            sectionTexts.Add(element.Text.Trim());
        }
        return sectionTexts;
    }
}