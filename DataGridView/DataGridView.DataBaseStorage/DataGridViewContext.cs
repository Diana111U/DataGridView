using DataGridView.AppConstants;
using DataGridView.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataGridView.DataBaseStorage
{
    public class DataGridViewContext : DbContext
    {
        /// <summary>
        /// Сущность <see cref="ApplicantModel"/>.
        /// </summary>
        public DbSet<ApplicantModel> Applicants { get; set; }

        /// <summary>
        /// Создаёт экземпляр <see cref="DataGridViewContext"/>.
        /// </summary>
        public DataGridViewContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=DataGridViewProjectDatabase;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(Constants.FullNameMaxLength);

                entity.Property(e => e.Gender)
                    .HasConversion<int>();

                entity.Property(e => e.FormOfEducation)
                    .HasConversion<int>();
    
                entity.Property(e => e.BirthDay)
                    .IsRequired();
            });
        }
    }
}
