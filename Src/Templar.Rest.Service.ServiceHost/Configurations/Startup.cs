using AutoMapper;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;
using System.Web.Http.SelfHost;
using System.Net.Http;
using System.Web.Http;
using System.Net;
namespace Templar.Rest.Service.ServiceHost
{
    public class Startup 
    {
        private IUnityContainer Container;
        private IMapper Mapper;
       
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {                
                if (this.Container != null) Container.Dispose();
            }
            // get rid of unmanaged resources
        }
        
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpListener listener = (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
            listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;


            Container = new UnityContainer();
            AutoMapper.MapperConfiguration mapper =  new AutoMapper.MapperConfiguration(
                 (service) =>
                 {
                     new TemplarMapperConfiguration().Configure(service);
                 }
                );

            //configure mapper
            this.Mapper = mapper.CreateMapper();
            this.Container.RegisterInstance<IMapper>(this.Mapper);

            //configure unity
            var containerConfig = new Configurations.DependencyConfiguration();
            containerConfig.Configure(this.Container);
            

            var config = new HttpConfiguration();
            config.DependencyResolver = new Configurations.UnityResolver(this.Container);
            config.Services.Replace(typeof(IAssembliesResolver), new Configurations.CustomAssemblyResolver());
            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();
            
            appBuilder.UseWebApi(config);            
        }
    }
}
