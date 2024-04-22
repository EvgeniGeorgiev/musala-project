

using NUnit.Framework.Legacy;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Reflection;

public class CareersPageInteractions(CareersPage careersPage, JobListingData jobListingData)
{
    private readonly CareersPage _careersPage = careersPage;
    private readonly JobListingData _jobListingData = jobListingData;

    internal void ClickApplyCTAOnJobPage()
    {
        _careersPage.ClickApplyCTAOnJobPage();
    }

    internal void ClickCheckOurOpenPositionsCTA()
    {
        _careersPage.ClickCheckOurOpenPositionsCTA();
    }

    internal bool IsApplyButtonIsPresentOnJobPage()
    {
        return _careersPage.IsApplyButtonIsPresentOnJobPage();
    }

    internal void PopulateApplyForm(string data)
    {
        _careersPage.PopulateApplyForm(data);
    }

    internal void SelectOptionInLocationFilter(string option)
    {
        _careersPage.ExpandLocationFilter();
        _careersPage.SelectOptionFromLocationFilter(option);
    }

    internal void SelectPositionFromCareersList(string option)
    {
        _careersPage.SelectPositionFromCareersList(option);
    }
    internal void SendApplyForm()
    {
        _careersPage.AcceptAdConcent();
        _careersPage.clickSendCTA();
    }

    internal string GetEmailErrorMessageFromApplyDialog()
    {
        return _careersPage.GetEmailErrorMessageFromApplyDialog();
    }

    internal string GetNameErrorMessageFromApplyDialog()
    {
        return _careersPage.GetNameErrorMessageFromApplyDialog();
    }

    internal string GetPhoneErrorMessageFromApplyDialog()
    {
        return _careersPage.GetPhoneErrorMessageFromApplyDialog();
    }

    internal string GetGeneralErrorMessageFromApplyDialog()
    {
        _careersPage.WaitForAjaxToComplete();
        return _careersPage.GetGeneralErrorMessageFromApplyDialog();
    }
    internal List<string> GetShowSectionsInJobPage()
    {
        return _careersPage.GetShowSectionsInJobPage();
    }

    internal void PrintAllJobsForCity(string location)
    {
        _jobListingData.SetJobListingData(location);
        

        if (_jobListingData.PositionsByCity.ContainsKey(location))
        {
            Console.WriteLine($"Location: {location}");
            List<JobListingData> locationListings = _jobListingData.PositionsByCity[location];
            foreach (var listing in locationListings)
            {
                Console.WriteLine($"Position: {listing.Position}");
                Console.WriteLine($"More Info: {listing.MoreInfo}");
            }
        }
        else
        {
            Console.WriteLine($"No job listings found for location: {location}");
        }
    }
}