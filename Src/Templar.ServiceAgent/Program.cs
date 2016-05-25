using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Templar.ServiceAgent
{
    class Program
    {
        private const string ServiceName = "Templar.ServiceAgent";
        static void Main()
        {
            
            HostFactory.Run(x =>
            {
                x.Service<AppHostFactory>(s =>
                {
                    s.ConstructUsing(() => new AppHostFactory());
                    s.WhenStarted(c => c.Start());
                    s.WhenStopped(c => c.Stop());
                });
                x.EnableShutdown();
                x.StartAutomaticallyDelayed();
                x.SetDescription(ServiceName);
                x.SetDisplayName(ServiceName);
                x.SetServiceName(ServiceName);
                x.RunAsNetworkService();                
            }
         );
        }

       
    }
}
