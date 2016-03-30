using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.Soap.Service;
using Templar.Soap.Service.Proxies;

namespace Templar.Service.SmokeTest
{
    [TestFixture]
    public class SoapServiceTest
    {
        [Test]
        public void ServiceIsUp()
        {
            using (var sandbox = new SandboxProxy<IClueService>("ClueService"))
            {
                sandbox.Service.Get(); 
            }
        }
    }
}
