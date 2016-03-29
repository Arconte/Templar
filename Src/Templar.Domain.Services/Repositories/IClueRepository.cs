using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.Domain.Entities;
using Templar.Domain.Values;

namespace Templar.Domain.Services.Repositories
{
    public interface IClueRepository
    {
        IEnumerable<ClueEntity> Search();
        void Add(ClueEntity Value);
        void Update(ClueEntity Value);
        void Delete(ClueEntity Value);
    }
}
