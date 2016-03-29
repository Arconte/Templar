using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templar.Soap.Service.ServiceHost.Configurations
{
    class MapperConfiguration
    {
        public void Configure(IMapperConfiguration MapperConfiguration)
        {
            var config = new Templar.Repository.SqlServer.Configuration.MapperConfiguration();
            config.Configure(MapperConfiguration);  
        }
    }
}
