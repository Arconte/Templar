using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.Domain.Entities;
using Templar.Domain.Services.Repositories;

namespace Templar.Domain.Services.Services
{
    public class ClueDomainService : IClueDomainService
    {
        private IClueRepository ClueRepository;
        public ClueDomainService(IClueRepository ClueRepository)
        {
            this.ClueRepository = ClueRepository; 
        }
        public void Add(Guid Id, string Content, DateTime DueDate, string Source)
        {
            var entity = new ClueEntity(Id,  Content, DueDate, Source);
            this.ClueRepository.Add(entity);
        }
    }
}
