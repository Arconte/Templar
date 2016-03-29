namespace Templar.SqlServer.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clue
    {
        public Guid Id { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(512)]
        public string Source { get; set; }
    }
}
