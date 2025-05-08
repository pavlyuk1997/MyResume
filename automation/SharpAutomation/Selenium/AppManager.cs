using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SharpAutomation.Selenium
{
    public class AppManager
    {
        public static IWebDriver Driver { get; private set; }

        public static void Start()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void Stop()
        {
            Driver.Quit();
        }
    }
}
