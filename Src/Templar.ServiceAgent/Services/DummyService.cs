using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Templar.ServiceAgent.Services
{
    public class DummyService  : IDummyService 
    {
        public DateTime GetDate()
        {            
            return DateTime.Now; 
        }
        private bool InternalPing()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://nuget.org");
            var response = client.GetAsync("").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new PingException(response.StatusCode.ToString());                
            }
            return true; 
        }
        public bool Ping()
        {
            var policy = Policy
              .Handle<PingException>()
              .Retry(3);

            policy.Execute(() => InternalPing());

            return true; 
        }
    }
}
