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
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Templar.ServiceAgent.Services;
using Templar.ServiceAgent.Jobs;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Templar.ServiceAgent
{
    public class AppHostFactory 
    {
        private IScheduler _Scheduler;
        private string GlobalPolicy = "General";
        private IUnityContainer Container = new UnityContainer();        
        public void Start()
        {
            this.ConfigureLogger();
            this.ConfigureExceptionHandling();
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

        private void ConfigureLogger()
        {            
            //var config = new LoggingConfiguration();
            //TextFormatter formatter = new TextFormatter();                          
            //var flatFileTraceListener = new RollingFlatFileTraceListener(
            //    @".\Error_log.txt",                     
            //        "----------------------------------------", 
            //        "----------------------------------------", 
            //        formatter, 5000, maxArchivedFiles : 100);
            //config.AddLogSource("Default", SourceLevels.All, true)
            //  .AddTraceListener(flatFileTraceListener);
            //LogWriter defaultWriter = new LogWriter(config);
            //Logger.SetLogWriter(defaultWriter);
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            Logger.SetLogWriter((new LogWriterFactory()).Create());

        }
        private void ConfigureExceptionHandling()
        {            
            ExceptionPolicyFactory factory = new ExceptionPolicyFactory(ConfigurationSourceFactory.Create());
            
            //var entries = new List<ExceptionPolicyEntry>();
            //entries.Add(new ExceptionPolicyEntry(typeof(Exception),
            //    PostHandlingAction.NotifyRethrow,
            //    new IExceptionHandler[] { 
            //        new LoggingExceptionHandler("Default", 100, 
            //            System.Diagnostics.TraceEventType.Error, 
            //            "ServiceAgent", 1, typeof(XmlExceptionFormatter),
            //            Logger.Writer)                    
            //    }));            

            //var policies = new List<ExceptionPolicyDefinition>() { 
            //    new ExceptionPolicyDefinition("General", entries )};

            ExceptionPolicy.SetExceptionManager(factory.CreateManager());
        }
        #endregion        
    }
}
