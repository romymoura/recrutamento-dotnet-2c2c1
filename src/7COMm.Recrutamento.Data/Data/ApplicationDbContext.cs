using System;
using System.Collections.Generic;
using System.Text;
using _7COMm.Recrutamento.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _7COMm.Recrutamento.Application.WebUI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contato>().HasKey(e => e.Id);
            base.OnModelCreating(builder);
        }
        public DbSet<Contato> Contatos { get; set; }
    }
}
