using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
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
    public class NetworkJobSample : IJob
    {
        private IDummyService DummyService;
        public NetworkJobSample(IDummyService DummyService)
        {
            this.DummyService = DummyService;
        }
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                this.DummyService.Ping();
            }
            catch (Exception ex)
            {
                Exception rethrow = null;
                if (ExceptionPolicy.HandleException(ex, "General", out rethrow))
                {
                    throw rethrow;
                }
            }        
        }
    }
}