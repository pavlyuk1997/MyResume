using Atata;
using NUnit.Framework;
using SharpAutomation.Atata.Pages;

namespace SharpAutomation.Atata.Tests
{
    public class AtataDemoTest : BaseTest
    {
        [Test]
        public void SearchAutomation()
        {
            const string query = "Automation";

            Go.To<HomePage>()
                .SearchFor(query)
                    .SearchInput.Should.Equal(query)
                    .Results.Count.Should.Equal(10)
                    .OpenFirstResult()
                        .BodySection.Should.Not.BeEmpty();
        }
    }
}
