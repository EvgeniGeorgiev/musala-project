using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

[Binding]
public class Hooks
{
    private static IWebDriver driver;

    [BeforeScenario]
    public static void BeforeScenario()
    {
        driver = new ChromeDriver();
    }

    [AfterScenario]
    public static void AfterScenario()
    {
        driver.Quit();
    }

    public static IWebDriver GetWebDriver()
    {
        return driver;
    }
}