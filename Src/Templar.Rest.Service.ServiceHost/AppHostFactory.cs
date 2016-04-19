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
        
        private IDisposable Host;
        public void Start()
        {
            
            string baseUri = ConfigurationManager.AppSettings["rest:url"];

            StartOptions options = new StartOptions();
            options.Urls.Add(baseUri.Replace("{machine}", "localhost"));
            options.Urls.Add(baseUri.Replace("{machine}", "127.0.0.1"));
            var serverName = System.Environment.MachineName;
            options.Urls.Add(baseUri.Replace("{machine}", Environment.MachineName));
            var fqhn = System.Net.Dns.GetHostEntry(serverName).HostName; //fully qualified hostname
            options.Urls.Add(baseUri.Replace("{machine}", fqhn));
            var hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in hostEntry.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    options.Urls.Add(baseUri.Replace("{machine}", ip.ToString()));
                    break;
                }
            }
            
            this.Host = WebApp.Start<Startup>(options);

#if DEBUG
            foreach (var item in options.Urls)
            {
                Console.WriteLine("Server running at {0} - press Enter to quit. ", item);
            }
#endif
        }
        public void Stop()
        {
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
