using System.Configuration;

public class ConfigurationSettings
{
    public static string GetBaseUrl()
    {
        //return ConfigurationManager.AppSettings["BaseUrl"];
        string configvalue1 = ConfigurationManager.AppSettings["BaseUrl"];
        return configvalue1;
    }
}