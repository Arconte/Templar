using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.Domain.Entities;
using Templar.Domain.Services.Repositories;
using Templar.Domain.Values;

namespace Templar.Repository.SqlServer
{
    public class ClueRepository : IClueRepository
    {
        private IMapper Mapper;
        public ClueRepository(IMapper Mapper)
        {
            this.Mapper = Mapper;            
        }
        public void Add(ClueEntity Value)
        {            
            using (var db = new Model.TemplarContext())
            {
                var clue = this.Mapper.Map<Model.Clue>(Value);
                db.Clues.Add(clue);
            }
        }

        public void Delete(ClueEntity Value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClueEntity> Search()
        {
            return new List<ClueEntity>(); 
        }

        public void Update(ClueEntity Value)
        {
            throw new NotImplementedException();
        }
    }
}
