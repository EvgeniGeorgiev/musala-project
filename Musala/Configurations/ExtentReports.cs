using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


public class ExtentManager
{
    public static ExtentReports extent;
    public static ExtentSparkReporter htmlReporter;

    public static ExtentReports GetExtent()
    {
        if (extent == null)
        {
            string reportPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory() + "\\..\\..\\..\\report.html"));
            htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        return extent;
    }

    public static void FlushReport()
    {
        extent.Flush();
    }
}