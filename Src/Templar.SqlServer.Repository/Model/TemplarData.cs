namespace Templar.SqlServer.Repository.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TemplarContext: DbContext
    {
        public TemplarContext()
            : base("name=TemplarData")
        {
        }

        public virtual DbSet<Clue> Clues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clue>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Clue>()
                .Property(e => e.Source)
                .IsUnicode(false);
        }
    }
}
