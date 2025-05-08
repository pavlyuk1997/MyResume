using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Playwright.Pages
{
    public class VacancyPage
    {
        private readonly IPage _page;

        public VacancyPage(IPage page)
        {
            _page = page;
        }

        public async Task<string> GetVacancyBodyTextAsync()
        {
            return await _page.InnerTextAsync("xpath=//*[contains(@class, 'vacancy-section')]");
        }
    }
}
