using CoffeMachine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeMachine.Infra.Context
{
    public class CoffeMachineDataContext : DbContext
    {
        public CoffeMachineDataContext()
        {
        }

        public DbSet<Coffe> Coffes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options.UseSqlite("Filename=MyDatabase.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coffe>(entity =>
            {
                entity.ToTable("coffe");
                entity.HasKey(e => e.Id).HasName("PK_coffeId");
                entity.Property(e => e.Name).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Value).IsRequired().HasColumnType("decimal(8,2)");
            });


            modelBuilder.Entity<Coffe>().HasData(new Coffe { Id = 1,  Name = "Capuccino", Value = 3.8M });
            modelBuilder.Entity<Coffe>().HasData(new Coffe { Id = 2, Name = "Mocha", Value = 4 });
            modelBuilder.Entity<Coffe>().HasData(new Coffe { Id = 3, Name = "Café com Leite", Value = 3 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
