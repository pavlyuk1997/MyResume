using OpenQA.Selenium;

namespace SharpAutomation.Pages
{
    public class HomePage : BasePage
    {
        private string Url => "https://dou.ua/";

        private IWebElement SearchInput { get { return Driver.FindElement(By.Id("txtGlobalSearch")); }  } 

        private IWebElement Logo { get { return Driver.FindElement(By.XPath("//a[@aria-label=' DOU Logo']")); } }

        public HomePage NavigateByUrl()
        {
            Driver.Navigate().GoToUrl(Url);
            Wait.Until(x => Logo != null);

            return this;
        }

        public SearchPage Search(string query)
        {
            Highlight(SearchInput);
            SearchInput.SendKeys(query + Keys.Enter);

            return new SearchPage();
        }
    }
}
