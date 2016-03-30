using AutoMapper;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.Domain.Services.Repositories;
using Templar.Domain.Services.Services;
using Templar.Repository.SqlServer;

namespace Templar.Soap.Service.ServiceHost
{
    class AppHostFactory : IDisposable
    {
        private IUnityContainer Container;
        private IMapper Mapper;        
        private IClueService _CustomService;
        private System.ServiceModel.ServiceHost _CustomServiceHost;
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
            

            this._CustomService = Container.Resolve<IClueService>();
            _CustomServiceHost = new System.ServiceModel.ServiceHost(_CustomService);
            _CustomServiceHost.Open();
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
                if (this._CustomServiceHost != null)
                {
                    try
                    {
                        this._CustomServiceHost.Close();
                    }
                    catch (Exception)
                    {
                        this._CustomServiceHost.Abort();
                    }
                }
                if (this.Container != null) Container.Dispose();
            }
            // get rid of unmanaged resources
        }
    }
}
