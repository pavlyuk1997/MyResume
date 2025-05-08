using NUnit.Framework;

namespace SharpAutomation.Selenium.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        [SetUp]
        public virtual void Setup()
        {
            AppManager.Start();
        }


        [TearDown]
        public virtual void Teardown()
        {
            AppManager.Driver.Quit();
        }
    }
}
