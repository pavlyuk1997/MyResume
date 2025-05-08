using NUnit.Framework;
using SharpAutomation.Selenium.Pages;

namespace SharpAutomation.Selenium.Tests
{
    public class SeleniumDemoTest : BaseTest
    {
        [Test]
        public void GoToVacancy()
        {
            const string query = "Automation";

            new HomePage()
                .NavigateByUrl()
                .Search(query)
                    .GetSearchInputText(out string searchInputText)
                    .GetResultsCount(out int resultsCount)
                    .TapFirstResult()
                        .GetBodyText(out string vacancyBodyText);

            Assert.That(searchInputText == query, "Search do not work as expected");
            Assert.That(resultsCount == 10, "Pagination do not works as expected");
            Assert.That(!string.IsNullOrEmpty(vacancyBodyText), "Pagination do not works as expected");
        }
    }
}

