using Microsoft.Practices.Unity;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templar.ServiceAgent
{
    public class JobFactory : IJobFactory
    {
        private readonly IUnityContainer Container;

        public JobFactory(IUnityContainer Container)
        {
            this.Container = Container;  
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                IJobDetail jobDetail = bundle.JobDetail;
                Type jobType = jobDetail.JobType;
                var job = (IJob)Container.Resolve(jobType);
                return job; 
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unity Configuration Error", ex);                
            }           
        }
        public void ReturnJob(IJob job)
        {
            var disposable = job as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
