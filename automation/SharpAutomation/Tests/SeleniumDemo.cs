using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SharpAutomation.Pages;

namespace SharpAutomation.Tests
{
    [TestFixture]
    public class SeleniumDemo
    {
        [SetUp]
        public void Setup()
        {
            AppManager.Start();
        }

        [Test]
        public void VerifySearchWorks()
        {
            const string query = "Automation";

            new HomePage()
                .Search(query)
                    .GetSearchInputText(out string searchInputText)
                    .GetResultsCount(out int resultsCount)
                    .TapFirstResult()
                        .GetBodyText(out string vacancyBodyText);

            Assert.That(searchInputText == query, "Search do not work as expected");
            Assert.That(resultsCount == 10, "Pagination do not works as expected");
            Assert.That(!string.IsNullOrEmpty(vacancyBodyText), "Pagination do not works as expected");
        }

        [TearDown]
        public void Teardown()
        {
            AppManager.Driver.Quit();
        }
    }
}

