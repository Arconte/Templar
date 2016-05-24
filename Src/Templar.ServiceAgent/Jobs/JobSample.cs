using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.ServiceAgent.Services;

namespace Templar.ServiceAgent.Jobs
{
    [DisallowConcurrentExecution]
    public class JobSample : IJob
    {
        private IDummyService DummyService;
        public JobSample(IDummyService DummyService)
        {
            this.DummyService = DummyService;
        }
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(string.Format("hello world at {0}",
                DateTime.Now));                        
        }
    }
}
