using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Templar.Service.FunctionalTest.Scenarios
{
    public class SampleScenario
    {
        public void GivenAcontext()
        {
            
        }
        public void WhenExecuteAnAction()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);

            HttpClient client = new HttpClient(new HttpClientHandler() 
                      {
                          UseDefaultCredentials = true
                      });
            
            client.BaseAddress = new Uri("http://localhost:7778/");
            var response = client.GetAsync("api/clues").Result;
            Assert.IsTrue(response.IsSuccessStatusCode);             
        }
        public void ThenValidateResult()
        {

        }
    }
}
