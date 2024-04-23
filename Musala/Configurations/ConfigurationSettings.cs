using Newtonsoft.Json;

public class ConfigurationSettings
{
    public class TestConfig
    {
        public required string Browser { get; set; }
        public required string BaseUrl { get; set; }

    }

    public static TestConfig GetConfig()
    {
        string json = System.IO.File.ReadAllText(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory() + "\\..\\..\\..\\config.json")));
        return JsonConvert.DeserializeObject<TestConfig>(json);
    }

    public static string GetBaseUrl()
    {
        TestConfig config = ConfigurationSettings.GetConfig();
        return config.BaseUrl;
    }

}