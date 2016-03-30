using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;
using Templar.Rest.Service.Imp;

namespace Templar.Rest.Service.ServiceHost.Configurations
{
    public class CustomAssemblyResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {            
            List<Assembly> assemblies = new List<Assembly>();
            
            // Add whatever additional assemblies you wish
            assemblies.Add(typeof(CluesController).Assembly);

            return assemblies;
        }
    }
}
