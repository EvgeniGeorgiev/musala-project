using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;


    private static IWebDriver driver;
    private static ExtentReports extent;
    private static ExtentTest test;
    //ExtentReports extent = ExtentManager.GetExtent();
    //ExtentTest test;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        extent = ExtentManager.GetExtent();
        test = extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
    }

    [BeforeScenario]
    public static void BeforeScenario()
    {
        driver = new ChromeDriver(); 

    }

    [AfterScenario]
    public void AfterScenario()
    {
        driver.Quit();

        if (_scenarioContext.TestError != null)
        {
            var error = _scenarioContext.TestError;
            Console.WriteLine("An error ocurred:" + error.Message);
            Console.WriteLine("It was of type:" + error.GetType().Name);
        }

        extent.Flush();
    }

    public static IWebDriver GetWebDriver()
    {
        return driver;
    }
}