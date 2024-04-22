using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class GlobalPage
{
    protected static IWebDriver webDriver;
    protected static WebDriverWait _wait;

    private readonly By NavigationSection = By.CssSelector("#menu.menu-main-nav-container [class*=menu-item] a");

    private readonly By AcceptCookiesCTA = By.CssSelector("#wt-cli-accept-all-btn");

    public GlobalPage()
    {
        webDriver = Hooks.GetWebDriver();
        _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
    }

    internal void AcceptCookies()
    {
        webDriver.FindElement(AcceptCookiesCTA).Click();
    }
    internal void Click(By element)
    {
        webDriver.FindElement(element).Click();
    }

    public void WaitForAjaxToComplete()
    {
        _wait.Until(driver =>
        {
            var ajaxIsComplete = (bool)((IJavaScriptExecutor)driver)
            .ExecuteScript("return (typeof jQuery == 'undefined' || jQuery.active == 0)");
            return ajaxIsComplete;
        });
    }

    internal bool IsElementVisible(By element)
    {
        IReadOnlyCollection<IWebElement> elementsList = webDriver.FindElements(element);
        return elementsList.Count() > 0;
    }

    internal string getCurrentURL()
    {
        return webDriver.Url;
    }

    internal void SwitchToNextTab()
    {
        List<string> windowHandles = new List<string>(webDriver.WindowHandles);
        int currentIndex = windowHandles.IndexOf(webDriver.CurrentWindowHandle);
        int nextIndex = (currentIndex + 1) % windowHandles.Count;
        webDriver.SwitchTo().Window(windowHandles[nextIndex]);
    }
    internal void NavigateToPage(string page)
    {
        webDriver.Navigate().GoToUrl(page);
    }

    internal void SelectSectionInTopNavigation(string section)
    {
        List<string> sections = new List<string>(section.Split(','));
        IReadOnlyCollection<IWebElement> sectionElements = new List<IWebElement>(webDriver.FindElements(NavigationSection));
        foreach (var sectionName in sections)
        {
            foreach (var element in sectionElements)
            {
                if (sectionName.ToLower() == element.Text.ToLower())
                {
                    element.Click();
                    break;
                }
            }
        }
    }

    internal void ClickElementFromListByText(By locator, string option)
    {
        bool wasAnOptionClicked = false;
        IReadOnlyCollection<IWebElement> elements = new List<IWebElement>(webDriver.FindElements(locator));
        foreach (var element in elements)
        {
            if (option == element.Text)
            {
                element.Click();
                wasAnOptionClicked = true;
                break;
            }
        }
        if (!wasAnOptionClicked) { throw new Exception("No element with text "+ option + " found. "); }
    }
}