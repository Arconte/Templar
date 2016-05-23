using AutoMapper;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;
using System.Web.Http.SelfHost;
using Templar.Domain.Services.Repositories;
using Templar.Domain.Services.Services;
using Templar.Repository.SqlServer;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using System.Net;
using System.Net.Sockets;

namespace Templar.Rest.Service.ServiceHost
{
    class AppHostFactory : IDisposable
    {
        private IScheduler _Scheduler;

        public void Start()
        {

            NameValueCollection config = (NameValueCollection)ConfigurationManager.GetSection("quartz");
            var SchedulerFactory = new StdSchedulerFactory(config);

            this._Scheduler = SchedulerFactory.GetScheduler();
            this._Scheduler.JobFactory = container.Resolve<Quartz.Spi.IJobFactory>();


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
         //   this.Dispose(true);
        }
        #region Configure Services
  
        #endregion
        
        public void Dispose()
        {
            
         //   Dispose(true);
            GC.SuppressFinalize(this);
        }
        // only if you use unmanaged resources directly 
        //~AppHostFactory()
        //{
        //    Dispose(false);
        //}
     
    }
}
