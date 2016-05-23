using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Templar.Domain.Services.Services;
using Templar.Soap.Service.Model;

namespace Templar.Soap.Service
{
    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Multiple,
         InstanceContextMode = InstanceContextMode.Single)]
    public class ClueService : IClueService
    {
        private IClueDomainService ClueDomainService;
        public ClueService(IClueDomainService ClueDomainService)
        {
            this.ClueDomainService = ClueDomainService; 
        }
        public void Add(Guid Id, string Source, string Content, DateTime DueDate)
        {
            this.ClueDomainService.Add(Id, Content, DueDate, Source);  
        }
        
        public IEnumerable<ClueRp> Get()
        {

            var user  = OperationContext.Current.ClaimsPrincipal == null ? "net " +  Thread.CurrentPrincipal.Identity.Name : OperationContext.Current.ClaimsPrincipal.Identity.Name;
            var type = OperationContext.Current.ClaimsPrincipal == null ?  "net " +  Thread.CurrentPrincipal.Identity.AuthenticationType : OperationContext.Current.ClaimsPrincipal.Identity.AuthenticationType;


            return new List<ClueRp>() { 
                new ClueRp{ 
                    Id  = Guid.NewGuid(),
                     Log = string.Format("windows {0}", System.Security.Principal.WindowsIdentity.GetCurrent().Name)                     
                },
                new ClueRp{ 
                    Id  = Guid.NewGuid(),
                     Log = string.Format("wcf type {0} : {1}",  type , user )                     
                }    
            }; 
        }
    }
}
