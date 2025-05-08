using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver => AppManager.Driver;

        protected WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        protected void Highlight(IWebElement element)
        {
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].style.border='2px solid red'", element);

            Thread.Sleep(2000);
        }
    }
}
