using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.Domain.Entities;
using Templar.Domain.Values;

namespace Templar.Domain.Services.Services
{
    public interface IClueDomainService
    {       

        void Add(Guid Id, string Content, DateTime DueDate, string Source);        

    }
}
