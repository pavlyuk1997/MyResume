using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Playwright.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page) => _page = page;

        private ILocator SearchInput => _page.Locator("#txtGlobalSearch");

        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://dou.ua/");
        }

        public async Task<SearchPage> SearchAsync(string query)
        {
            await SearchInput.ClickAsync();
            await SearchInput.FillAsync(query);
            await _page.Keyboard.PressAsync("Enter");

            return new SearchPage(_page);
        }
    }
}
