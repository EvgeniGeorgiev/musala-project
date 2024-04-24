
public class GlobalPageInteractions(GlobalPage globalPage)
{
    private readonly GlobalPage _globalPage = globalPage;

    internal void AcceptCookies()
    {
        _globalPage.AcceptCookies();
    }
    public void NavigateToPage(string page)
    {
        _globalPage.NavigateToPage(page);
    }

    internal string getCurrentURL()
    {
        return _globalPage.getCurrentURL();
    }

    internal void SelectSectionInTopNavigation(string section)
    {
        _globalPage.SelectSectionInTopNavigation(section);
    }
}