using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Templar.Service.SmokeTest
{
    [TestFixture]
    public class RestServiceTest
    {
        [Test]
        public void ServiceIsUpTest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress =new Uri(ConfigurationManager.AppSettings["rest:url"]);
            var response =   client.GetAsync("api/clues").Result;
            Assert.IsTrue(response.IsSuccessStatusCode); 
        }
    }
}
