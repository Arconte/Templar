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

        public void Update(ClueEntity Value)
        {
            using (var db = new Model.TemplarContext())
            {                
                var clue = db.Clues.Where(c => c.Id == Id).FirstOrDefault();                
                if (clue != null)
                {
                    clue.Content = Value.Content;
                    clue.DueDate = Value.DueDate;
                    clue.Source = Value.Source;                      
                    db.SaveChanges();
                }
            }
        }
    }
}
