using Atata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutomation.Atata.Tests
{
    public class BaseTest
    {
        private static AtataContext _context;

        [OneTimeSetUp]
        public void SetUp()
        {
            _context = AtataContext.Configure()
                .UseChrome()
                .Build();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _context?.Dispose();
        }
    }
}
