using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Selenium.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver => AppManager.Driver;

        protected WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        protected void Highlight(IWebElement element)
        {
            var js = (IJavaScriptExecutor)Driver;

            // Inject CSS for flashing border (only once)
            js.ExecuteScript(@"
                if (!document.getElementById('highlight-style')) {
                    const style = document.createElement('style');
                    style.id = 'highlight-style';
                    style.innerHTML = `
                        @keyframes flash-border {
                            0% { border: 2px solid red; }
                            50% { border: 2px solid transparent; }
                            100% { border: 2px solid red; }
                        }
                        .highlight-flash {
                            animation: flash-border 1s ease-in-out 2;
                        }
                    `;
                    document.head.appendChild(style);
                }
            ");

            js.ExecuteScript("arguments[0].classList.add('highlight-flash');", element);

            // Wait for the animation to complete, then remove class
            Thread.Sleep(2500); // 2s animation + small buffer
            js.ExecuteScript("arguments[0].classList.remove('highlight-flash');", element);
        }


    }
}
