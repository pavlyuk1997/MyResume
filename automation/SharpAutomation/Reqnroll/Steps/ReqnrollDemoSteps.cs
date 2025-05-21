using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Reqnroll.Steps
{
    public class ReqnrollDemoSteps
    {
        [Binding]
        public class SearchSteps
        {
            private IWebDriver _driver;

            [Given("I open the DOU homepage")]
            public void OpenDou()
            {
                _driver = new ChromeDriver();
                _driver.Navigate().GoToUrl("https://dou.ua/");
            }

            [When(@"I search for ""(.*)""")]
            public void Search(string query)
            {
                var input = _driver.FindElement(By.Id("txtGlobalSearch"));
                input.SendKeys(query + Keys.Enter);
            }

            [Then("I should see at least 1 search result")]
            public void VerifyResults()
            {
                var results = _driver.FindElements(By.XPath("//div[@class='gsc-webResult gsc-result']"));
                Assert.That(results.Count, Is.GreaterThan(0));
                _driver.Quit();
            }
        }
    }
}