using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.Domain.Services.Repositories;
using Templar.Domain.Services.Services;
using Templar.Repository.SqlServer;

namespace Templar.Rest.Service.ServiceHost.Configurations
{
    public class DependencyConfiguration
    {
        public void Configure(IUnityContainer Container)
        {
            Container.RegisterType<IClueRepository, ClueRepository>();
            Container.RegisterType<IClueDomainService, ClueDomainService>();
        }
    }
}
