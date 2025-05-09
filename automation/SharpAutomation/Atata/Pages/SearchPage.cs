using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Atata.Pages
{
    using _ = SearchPage;

    public class SearchPage : Page<_>
    {
        public SearchPage()
        {
            Results?.WaitTo.Not.BeEmpty();
        }

        [FindByXPath("//input[@name='search']")]
        public TextInput<_> SearchInput { get; private set; }

        public ControlList<SearchResultItem, _> Results { get; private set; }

        public _ GetSearchInputValue(out string text)
        {
            text = SearchInput.Value;

            return this;
        }

        public _ GetResultsCount(out int count)
        {
            count = Results.Count;

            return this;
        }

        public VacancyPage OpenFirstResult()
        {
            return Results[0].Link.ClickAndGo<VacancyPage>();
        }
    }

    [ControlDefinition("div[@class='gsc-webResult gsc-result']")]
    public class SearchResultItem : Control<_>
    {
        [FindByXPath(".//a[@class='gs-title']")]
        public Link<_> Link { get; private set; }
    }
}
