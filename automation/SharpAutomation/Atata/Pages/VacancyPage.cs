using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Atata.Pages
{
    using _ = VacancyPage;

    public class VacancyPage : Page<_>
    {
        [FindByXPath("//*[contains(@class, 'vacancy-section')]")]
        public Text<_> BodySection { get; private set; }

        public _ GetBo()
        {
            return BodySection.Content.Should.Not.BeEmpty();
        }
    }
}
