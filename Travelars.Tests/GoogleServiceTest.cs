using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleApiService;
using NUnit.Framework;
using Travelars.DTO.GoogleModels;

namespace Travelars.Tests
{
    [TestFixture]
    public class GoogleServiceTest
    {
        [Test]
        public void Test()
        {
            var provider = new GoogleApiProvider();
            provider.SearchPlace(new SearchPlaceRequest()
            {
                Address = "Kharkiv",
                Keyword = "парк развлечений"
            });
            Assert.IsTrue(true);
        }
    }
}
