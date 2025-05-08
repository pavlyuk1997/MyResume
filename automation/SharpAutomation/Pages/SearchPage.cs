using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage()
        {
            Wait.Until(x => SearchInput != null);
        }

        private IWebElement SearchInput { get { return Driver.FindElement(By.XPath("//input[@name='search']")); } }

        private IWebElement Logo { get { return Driver.FindElement(By.XPath("//a[@aria-label=' DOU Logo']")); } }

        private ResultElement[] Results { get { return [.. Driver.FindElements(By.XPath("//div[@class= 'gsc-webResult gsc-result']")).Select(x=>new ResultElement(x))]; } }

        public SearchPage GetSearchInputText(out string text)
        {
            text = SearchInput.GetAttribute("value");

            return this;
        }

        public SearchPage GetResultsCount(out int count)
        {
            count = Results.Length;
            return this;
        }

        public VacancyPage TapFirstResult()
        {
            var firstResult = Results.First().Link;

            Highlight(firstResult);
            firstResult.Click();

            return new VacancyPage();
        }

        public class ResultElement 
        {
            private readonly IWebElement container;

            public ResultElement(IWebElement container)
            {
                this.container = container;
            }

            public IWebElement Link { get { return container.FindElement(By.XPath("//a[@class= 'gs-title']")); } }
        }

    }
}
