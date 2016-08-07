namespace MvcGeekAcademy.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MvcGeeksDbContext : DbContext
    {
        public MvcGeeksDbContext()
            : base("name=MvcGeeksDbContext")
        {
        }

        public virtual DbSet<student> students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<student>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

           
        }
    }
}
