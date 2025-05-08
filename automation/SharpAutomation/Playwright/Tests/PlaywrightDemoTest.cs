using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using SharpAutomation.Playwright.Pages;

namespace SharpAutomation.Playwright.Tests
{
    [TestFixture]
    public class PlaywrightDemoTest : PageTest
    {
        [Test]
        public async Task SearchAndOpenVacancy()
        {
            var home = new HomePage(Page);
            await home.NavigateAsync();

            var results = await home.SearchAsync("Automation");
            await results.WaitPageAsync();

            var inputText = await results.GetSearchInputValueAsync();
            var count = await results.GetResultsCountAsync();

            Assert.That(inputText, Is.EqualTo("Automation"), "Search term mismatch");
            Assert.That(count, Is.EqualTo(10), "Expected 10 search results");

            var vacancy = await results.ClickFirstResultAsync();
            var body = await vacancy.GetVacancyBodyTextAsync();

            Assert.That(body, Is.Not.Null.And.Not.Empty, "Vacancy body is empty");
        }
    }
}
