using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.ServiceAgent.Services;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
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
            try
            {
                Console.WriteLine(string.Format("hello world at {0}",
                this.DummyService.GetDate()));                        
                
                
            }
            catch (Exception ex)
            {
                try
                {
                    ExceptionPolicy.HandleException(ex, "General");
                }
                catch (Exception e)
                {
                       throw;
                }
                throw;
            }            
        }
    }
}
