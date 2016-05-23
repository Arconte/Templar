using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.BDDfy;

namespace Templar.Service.FunctionalTest.Stories
{
    [Story(  Title ="Story0001",  AsA = "User" , IWant ="Call service" , SoThat ="Business value" )]
    public class SampleStory
    {
        [Test]
        [Category("L2")]
        [Owner("gcvalderrama@hotmail.com")]
        public void SampleScenario()
        {
            var scenario = new Scenarios.SampleScenario();
            scenario.BDDfy(); 
        }

        [Test]
        [Category("L2")]
        [Owner("gcvalderrama@hotmail.com")]
        public void SoapSampleScenario()
        {
            var scenario = new Scenarios.SoapSampleScenario();
            scenario.BDDfy();
        }
    }
}
