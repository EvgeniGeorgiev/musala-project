using OpenQA.Selenium;

public class JobListingData : GlobalPage
{
    public string Position { get; set; }
    public string MoreInfo { get; set; }

    public By PositionLocator { get; } = By.CssSelector(".card-jobsHot .card-jobsHot__title");
    public By MoreInfoLocator { get; } = By.CssSelector(".card-jobsHot a");


    public Dictionary<string, List<JobListingData>> PositionsByCity { get; private set; }

    public JobListingData()
    {
        PositionsByCity = new Dictionary<string, List<JobListingData>>();
    }

    internal void SetJobListingData(string currentCity)
    {
        IList<IWebElement> positionElements = new List<IWebElement>(webDriver.FindElements(PositionLocator));
        IList<IWebElement> moreInfoElements = new List<IWebElement>(webDriver.FindElements(MoreInfoLocator));

        List<JobListingData> cityListings = new List<JobListingData>();

        for (int i = 0; i < positionElements.Count; i++)
        {
            cityListings.Add(
                new JobListingData { Position = positionElements[i].Text, MoreInfo = moreInfoElements[i].GetAttribute("href") }
                );
        }

        if (cityListings.Count > 0)
        {
            PositionsByCity[currentCity] = cityListings;
        }
    }
}