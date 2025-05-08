using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Pages
{
    public class VacancyPage : BasePage
    {
        public VacancyPage()
        {
            Wait.Until(x => VacancyBody != null);
        }

        private IWebElement VacancyBody { get { return Driver.FindElement(By.XPath("//*[contains(@class, 'vacancy-section')]")); } }

        public VacancyPage GetBodyText (out string text) 
        {
            Highlight(VacancyBody);
            text = VacancyBody.Text;
            return this;
        }
    }
}
