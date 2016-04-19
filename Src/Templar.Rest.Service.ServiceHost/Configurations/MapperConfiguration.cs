using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templar.Rest.Service.ServiceHost
{
    class TemplarMapperConfiguration
    {
        public void Configure(IMapperConfiguration Configuration)
        {
            var repcon = new Templar.Repository.SqlServer.Configuration.MapperConfiguration();
            repcon.Configure(Configuration);
        }
    }
}
