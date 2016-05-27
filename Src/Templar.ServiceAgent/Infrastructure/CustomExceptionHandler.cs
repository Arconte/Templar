using Common.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Templar.ServiceAgent.Infrastructure
{
    public class CustomHandlerData : ExceptionHandlerData
    {
      public CustomHandlerData()
          : base(typeof(CustomExceptionHandler))
      { 
      
      }
      public override IExceptionHandler BuildExceptionHandler()
      {
          return new CustomExceptionHandler(this.logCategory); 
      }

      [ConfigurationProperty("logCategory", IsRequired = false)]
      public String logCategory
      {
          get { return (String)this["logCategory"]; }
          set { this["logCategory"] = value; }
      }
    }

    [ConfigurationElementType(typeof(CustomHandlerData))]
    public class CustomExceptionHandler : IExceptionHandler
    {
        private readonly string logCategory;
        private readonly int eventId;
        private readonly TraceEventType severity;
        private readonly string defaultTitle;        
        private readonly int minimumPriority;
        private readonly Microsoft.Practices.EnterpriseLibrary.Logging.LogWriter logWriter;

        public CustomExceptionHandler(string logCategory) {
            this.logCategory = logCategory;                        
            this.eventId = 100;
            this.severity =  TraceEventType.Error;
            this.defaultTitle = "Templar.ServiceAgent";
            this.minimumPriority = 1;            
            this.logWriter = Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Writer;            
        }        
        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            exception.Data.Add("test", "data");
            if (exception != null && !(exception is ThreadAbortException))
            {
                
                WriteToLog(this.CreateMessage(exception, handlingInstanceId), exception.Data);
            }
            var target = new UserFriendlyException(handlingInstanceId);
            return target;
        }
        private string CreateMessage(Exception exception, Guid handlingInstanceID)
        {
            StringWriter writer = null;
            StringBuilder stringBuilder = null;
            try
            {
                writer = new StringWriter(CultureInfo.InvariantCulture);
                ExceptionFormatter formatter = new XmlExceptionFormatter(writer, exception, handlingInstanceID);                
                formatter.Format();
                stringBuilder = writer.GetStringBuilder();
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return stringBuilder.ToString();
        }                                

        protected void WriteToLog(string logMessage, IDictionary exceptionData)
        {
            Dictionary<string, object> entries = new Dictionary<string, object>();  
            foreach (DictionaryEntry dataEntry in exceptionData)
            {
                entries.Add(dataEntry.Key.ToString(), dataEntry.Value);                                    
            }
            var entry = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry(logMessage, logCategory, minimumPriority, eventId, severity, defaultTitle, entries);
            this.logWriter.Write(entry);
        }
    }
}
