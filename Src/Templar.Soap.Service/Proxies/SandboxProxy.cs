using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Templar.Service.Proxies
{
    public class SandboxProxy<TServiceContract> : IDisposable
    {
        private ChannelFactory<TServiceContract> Factory;
        public TServiceContract Service { get; private set; } 
        
        public SandboxProxy(string EndpointConfigurationName)
        {            
            this.Factory = new ChannelFactory<TServiceContract>(EndpointConfigurationName);
            this.Service = Factory.CreateChannel();
        }        
        public void Dispose()
        {
            try
            {    
                this.Factory.Close();
            }
            catch (CommunicationException e)
            {
                this.Factory.Abort();     
            }
            catch (TimeoutException e)
            {
                this.Factory.Abort();
            }
            catch (Exception e)
            {
                this.Factory.Abort();  
                throw;
            }
        }
    }
}
