using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GraffLeilaoGuilherme.Models;

namespace GraffLeilaoGuilherme.DAL
{
    public class LeilaoContext : DbContext
    {
        public LeilaoContext() : base("LeilaoContext")
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Lance> Lances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Lance>()
            //    .HasKey(c => new { c.pessoaID, c.produtoID });

            //modelBuilder.Entity<Pessoa>()
            //    .HasMany(c => c.lances)
            //    .WithRequired()
            //    .HasForeignKey(c => c.pessoaID);

            //modelBuilder.Entity<Produto>()
            //    .HasMany(c => c.lances)
            //    .WithRequired()
            //    .HasForeignKey(c => c.produtoID);
        }
    }
}