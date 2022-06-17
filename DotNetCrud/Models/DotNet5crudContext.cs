using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DotNetCrud.Models
{
    public partial class DotNet5crudContext : DbContext
    {
        public DotNet5crudContext()
        {
        }

        public DotNet5crudContext(DbContextOptions<DotNet5crudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employess> Employesses { get; set; }

        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {

        // optionsBuilder.UseSqlServer("Server=DESKTOP-5FBSLNK;Database=DotNet5crud;Integrated Security=True");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employess>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Employess");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
