﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_BusinessLogic
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RepairDBEntities : DbContext
    {
        public static RepairDBEntities _context = new RepairDBEntities();
        public RepairDBEntities()
            : base("name=RepairDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<HomeTechModel> HomeTechModel { get; set; }
        public virtual DbSet<HomeTechType> HomeTechType { get; set; }
        public virtual DbSet<RepairParts> RepairParts { get; set; }
        public virtual DbSet<ReqStatusType> ReqStatusType { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
    }
}
