using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templar.Soap.Service.ServiceHost
{
    class AppHostFactory : IDisposable
    {
        private IUnityContainer _Container;
        private IClueService _CustomService;
        private System.ServiceModel.ServiceHost _CustomServiceHost;
        public void Start()
        {
            _Container = new UnityContainer();
            ConfigureContainer();
            ConfigureServices();
        }
        public void Stop()
        {
            this.Dispose(true);
        }
        #region Configure Services
        private void ConfigureServices()
        {
            this._CustomService = _Container.Resolve<IClueService>();
            _CustomServiceHost = new System.ServiceModel.ServiceHost(_CustomService);
            _CustomServiceHost.Open();
        }
        #endregion
        #region Configure Container
        private void ConfigureContainer()
        {
            this._Container.RegisterType<IClueService, ClueService>();
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
                if (this._Container != null) _Container.Dispose();
            }
            // get rid of unmanaged resources
        }
    }
}
