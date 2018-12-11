using System;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CannabisWeb.Models
{
    public partial class cannabis_dataContext : DbContext
    {
        public cannabis_dataContext()
        {
        }

        public cannabis_dataContext(DbContextOptions<cannabis_dataContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

                optionsBuilder.UseSqlServer("Data Source=cannabis.cmt2wsntgequ.us-east-2.rds.amazonaws.com;database=cannabis_data;User ID=cannabis;Password=10041600;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Types>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cbd)
                    .HasColumnName("cbd")
                    .HasMaxLength(50);

                entity.Property(e => e.EaseMigraine).HasColumnName("easeMigraine");

                entity.Property(e => e.High).HasColumnName("high");

                entity.Property(e => e.IncreaseApetite).HasColumnName("increaseApetite");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PainReliever).HasColumnName("painReliever");

                entity.Property(e => e.PostedBy).HasColumnName("postedBy");

                entity.Property(e => e.PostedDate)
                    .HasColumnName("postedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReduceAnxiety).HasColumnName("reduceAnxiety");

                entity.Property(e => e.SideEffects)
                    .HasColumnName("sideEffects")
                    .HasMaxLength(50);

                entity.Property(e => e.Thc)
                    .HasColumnName("thc")
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.PostedByNavigation)
                    .WithMany(p => p.Types)
                    .HasForeignKey(d => d.PostedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("postedBy_to_Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(10);

                entity.Property(e => e.FName)
                    .HasColumnName("f_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LName)
                    .HasColumnName("l_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);
            });
        }
    }
}
