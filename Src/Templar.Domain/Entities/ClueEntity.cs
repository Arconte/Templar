using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templar.Domain.Entities
{
    public class ClueEntity
    {
        public Guid Id { get; set; }
        public DateTime DueDate { get; }
        public string Content { get; }
        public string Source { get; }

        public ClueEntity(Guid Id,
            string Content,
            DateTime DueDate,
            string Source)
        {
            this.Id = Id;  
            this.DueDate = DueDate;
            this.Content = Content;
            this.Source = Source;
        }
    }
}
