﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PakistaniTwitter.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PakistaniTwitterDBEntities : DbContext
    {
        public PakistaniTwitterDBEntities()
            : base("name=PakistaniTwitterDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Followers_PakistaniTwitter> Followers_PakistaniTwitter { get; set; }
        public virtual DbSet<Tweets_PakistaniTwitter> Tweets_PakistaniTwitter { get; set; }
        public virtual DbSet<Users_PakistaniTwitter> Users_PakistaniTwitter { get; set; }
    }
}
