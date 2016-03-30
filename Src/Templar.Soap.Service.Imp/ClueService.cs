using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
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
            return new List<ClueRp>(); 
        }
    }
}
