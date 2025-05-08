using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Pages
{
    public class HomePage : BasePage
    {
        private string Url => "https://dou.ua/";

        public HomePage()
        {
            Navigate();
            Wait.Until(x => Logo != null);
        }
       
        private IWebElement SearchInput { get { return Driver.FindElement(By.Id("txtGlobalSearch")); }  } 

        private IWebElement Logo { get { return Driver.FindElement(By.XPath("//a[@aria-label=' DOU Logo']")); } }

        public void Navigate() => Driver.Navigate().GoToUrl(Url);

        public SearchPage Search(string query)
        {
            Highlight(SearchInput);
            SearchInput.SendKeys(query + Keys.Enter);

            return new SearchPage();
        }
    }
}
