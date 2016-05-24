using AutoMapper;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Quartz;
using System.Collections.Specialized;
using Quartz.Impl;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Templar.ServiceAgent.Services;
using Templar.ServiceAgent.Jobs;

namespace Templar.ServiceAgent
{
    public class AppHostFactory 
    {
        private IScheduler _Scheduler;
        private string GlobalPolicy = "General";
        private IUnityContainer Container = new UnityContainer(); 
        public void Start()
        {

            this.ConfigureDependencies(); 

            NameValueCollection config = (NameValueCollection)ConfigurationManager.GetSection("quartz");
            var SchedulerFactory = new StdSchedulerFactory(config);
            this._Scheduler = SchedulerFactory.GetScheduler();
            this._Scheduler.JobFactory = new JobFactory(Container);
            this._Scheduler.Start();
        }
        public void Stop()
        {
            try
            {
                if (_Scheduler != null)
                {
                    this._Scheduler.PauseTriggers(global::Quartz.Impl.Matchers.GroupMatcher<TriggerKey>.AnyGroup());
                    _Scheduler.Shutdown(true);
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, GlobalPolicy);
            }   
        }
        #region Configure Dependencies

        private void ConfigureDependencies()
        {
            this.Container.RegisterType<IDummyService, DummyService>();
            

        }
        #endregion        
        
     
    }
}
