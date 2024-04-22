

using NUnit.Framework.Legacy;
using System;

public class CompanyPageInteractions(CompanyPage companyPage)
{
    private readonly CompanyPage _companyPage = companyPage;

    internal bool IsLeadershipSectionVisible()
    {
        return _companyPage.IsLeadershipSectionVisible();
    }
    internal bool IsFacebookProfilePictureVisible()
    {
        return _companyPage.IsFacebookProfilePictureVisible();
    }

    internal void ClickCompanyFacebookIcon()
    {
        _companyPage.ClickCompanyFacebookIcon();
        _companyPage.SwitchToNextTab();
        _companyPage.WaitForAjaxToComplete();
    }
}