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
using Templar.Repository.SqlServer.Model;

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
                db.SaveChanges();  
            }
        }

        public void Delete(Guid Id)
        {
            using (var db = new Model.TemplarContext())
            {
                var clue = db.Clues.Where(c => c.Id == Id ).FirstOrDefault();
                if (clue != null)
                {
                    db.Clues.Remove(clue);
                    db.SaveChanges();  
                }                
            }
        }

        public IEnumerable<ClueEntity> Search()
        {
            return new List<ClueEntity>(); 
        }

        public void Update(ClueEntity Entity)
        {
            using (var db = new Model.TemplarContext())
            {                
                var clue = db.Clues.Where(c => c.Id == Entity.Id).FirstOrDefault();                
                if (clue != null)
                {
                    clue.Content = Entity.Content;
                    clue.DueDate = Entity.DueDate;
                    clue.Source = Entity.Source;                      
                    db.SaveChanges();
                }
            }
        }
    }
}
