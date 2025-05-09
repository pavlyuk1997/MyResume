using Atata;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Atata.Pages
{
    using _ = HomePage;

    [Url("https://dou.ua/")]
    public class HomePage : Page<_>
    {
        [PressEnter(TriggerEvents.AfterSet)]
        [FindById("txtGlobalSearch")]
        public TextInput<_> GlobalSearch { get; private set; }

        public SearchPage SearchFor(string query)
        {
            GlobalSearch.Set(query);

            return Go.To<SearchPage>();
        }
    }
}
