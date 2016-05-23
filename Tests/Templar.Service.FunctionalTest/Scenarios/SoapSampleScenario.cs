using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.Service.Proxies;
using Templar.Soap.Service;

namespace Templar.Service.FunctionalTest.Scenarios
{
    
    public class SoapSampleScenario
    {
        IEnumerable<Soap.Service.Model.ClueRp> Result;
        public void GivenAcontext()
        {
            
        }
        public void WhenExecuteAnAction()
        {
            using (SandboxProxy<IClueService> Proxy = new SandboxProxy<IClueService>("ClueService"))
            {
                Result = Proxy.Service.Get();
            }
        }
        public void ThenValidateResult()
        {
            Assert.IsNotEmpty(Result); 
        }
    }
}
