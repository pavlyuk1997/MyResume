using Microsoft.Playwright;
using OpenQA.Selenium;
using SharpAutomation.Selenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Playwright.Pages
{
    public class SearchPage
    {
        private readonly IPage _page;

        public SearchPage(IPage page)
        {
            _page = page;
        }

        private ILocator SearchInput => _page.Locator("xpath=//input[@name='search']");

        private ILocator Results => _page.Locator("xpath=//div[@class='gsc-webResult gsc-result']");

        public async Task<SearchPage> WaitPageAsync()
        {
            await SearchInput.WaitForAsync();
            await Results.First.WaitForAsync();

            return this;
        }

        public async Task<string> GetSearchInputValueAsync()
        {
            return await _page.InputValueAsync("xpath=//input[@name='search']");
        }

        public async Task<int> GetResultsCountAsync()
        {
            return await Results.CountAsync();
        }

        public async Task<VacancyPage> ClickFirstResultAsync()
        {
            await Results.Nth(0).Locator("xpath=.//a[@class='gs-title']").First.ClickAsync();
            await _page.Locator("xpath=//*[contains(@class, 'vacancy-section')]").WaitForAsync();
            return new VacancyPage(_page);
        }
    }
}
