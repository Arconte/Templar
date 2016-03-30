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

namespace Templar.Rest.Service.ServiceHost
{
    class AppHostFactory : IDisposable
    {
        private IUnityContainer Container;
        private IMapper Mapper;
        private HttpSelfHostServer Server;
        public void Start()
        {
            Container = new UnityContainer();           

            AutoMapper.MapperConfiguration conmapper = new AutoMapper.MapperConfiguration(
                 (service) =>{
                     var repcon = new Templar.Repository.SqlServer.Configuration.MapperConfiguration();
                     repcon.Configure(service); 
                 }
                );
            this.Mapper = conmapper.CreateMapper(); 
            Configure();
        }
        public void Stop()
        {
            this.Dispose(true);
        }
        #region Configure Services
        private void Configure()
        {
            this.Container.RegisterInstance<IMapper>(this.Mapper);
            var containerConfig = new Configurations.DependencyConfiguration();
            containerConfig.Configure(this.Container);
            
            var url = ConfigurationManager.AppSettings["rest:url"];
            var config = new HttpSelfHostConfiguration(url);
            config.DependencyResolver = new Configurations.UnityResolver(this.Container);
            config.Services.Replace(typeof(IAssembliesResolver), new Configurations.CustomAssemblyResolver());            
            config.MapHttpAttributeRoutes();
            config.EnsureInitialized(); 
            this.Server = new HttpSelfHostServer(config);
            this.Server.OpenAsync().Wait(); 
        }
        #endregion
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // only if you use unmanaged resources directly 
        ~AppHostFactory()
        {
            Dispose(false);
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Server != null)
                {                    
                    this.Server.CloseAsync().Wait(); 
                }
                if (this.Container != null) Container.Dispose();
            }
            // get rid of unmanaged resources
        }
    }
}
