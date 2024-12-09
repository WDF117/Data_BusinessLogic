using Data_BusinessLogic.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data_BusinessLogic.DB
{
    public class RepairDBContext : DbContext
    {
        public DbSet<Comments> Comments { get; set; }
        public DbSet<HomeTechModel> HomeTechModels { get; set; }
        public DbSet<HomeTechType> HomeTechTypes { get; set; }
        public DbSet<RepairParts> RepairParts { get; set; }
        public DbSet<ReqStatusType> ReqStatusTypes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Comments -> Request
            modelBuilder.Entity<Comments>()
                .HasOne(c => c.Request) 
                .WithMany(r => r.Comments) 
                .HasForeignKey(c => c.RequestId) 
                .OnDelete(DeleteBehavior.Cascade); 

            // Comments -> User (Master)
            modelBuilder.Entity<Comments>()
                .HasOne(c => c.Master)
                .WithMany() 
                .HasForeignKey(c => c.MasterId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Request -> HomeTechType
            modelBuilder.Entity<Request>()
                .HasOne(r => r.HomeTechType)
                .WithMany()
                .HasForeignKey(r => r.HomeTechTypeId);

            // Request -> HomeTechModel
            modelBuilder.Entity<Request>()
                .HasOne(r => r.HomeTechModel)
                .WithMany()
                .HasForeignKey(r => r.HomeTechModelId)
                .IsRequired(false);

            // Request -> RepairParts
            modelBuilder.Entity<Request>()
                .HasOne(r => r.RepairParts)
                .WithMany()
                .HasForeignKey(r => r.RepairPartsId)
                .IsRequired(false);

            // Request -> User (Client)
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Client)
                .WithMany()
                .HasForeignKey(r => r.ClientId);

            // Request -> User (Master)
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Master)
                .WithMany()
                .HasForeignKey(r => r.MasterId)
                .IsRequired(false);

            // Request -> ReqStatusType
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Status)
                .WithMany()
                .HasForeignKey(r => r.StatusId);
            //User -> UserType
            modelBuilder.Entity<User>()
                .HasOne(r => r.Type)
                .WithMany()
                .HasForeignKey(r => r.UserTypeId);
        }

    }
}
/*
Enable-Migrations
Add-Migration InitialCreate
Update-Database

 */
