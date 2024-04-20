

using NUnit.Framework.Legacy;
using System;

public class LandingPageInteractions(LandingPage landingPage)
{
    private readonly LandingPage _landingPage = landingPage;


    internal void ClickOnContactUs()
    {
        _landingPage.ClickOnContactUs();
    }

    internal void ClickTheSendButtonInTheContactUsDialog()
    {
        _landingPage.ClickTheSendButtonInTheContactUsDialog();
    }

    internal string GetEmailErrorMessageFromTheContactUsDialog()
    {
        return _landingPage.GetEmailErrorMessageFromTheContactUsDialog();
    }
    internal string GetDialogErrorMessageFromTheContactUsDialog()
    {
        return _landingPage.GetDialogErrorMessageFromTheContactUsDialog();
    }

    internal void PopulateContactUsDialogWithWrongEmailData()
    {
        _landingPage.PopulateContactUsDialogWithWrongEmailData();
    }
}