using NUnit.Framework;

namespace SharpAutomation.Tests
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
