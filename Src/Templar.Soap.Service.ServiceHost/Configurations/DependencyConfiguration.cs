using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.Domain.Services.Repositories;
using Templar.Domain.Services.Services;
using Templar.Repository.SqlServer;

namespace Templar.Soap.Service.ServiceHost.Configurations
{
    class DependencyConfiguration
    {
        public void Configure(IUnityContainer Container)
        {
            Container.RegisterType<IClueRepository, ClueRepository>();
            Container.RegisterType<IClueDomainService, ClueDomainService>();

            Container.RegisterType<IClueService, ClueService>(); 
        }
    }
}
