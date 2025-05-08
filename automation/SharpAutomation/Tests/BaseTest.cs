using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
