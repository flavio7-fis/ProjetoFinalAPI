using Microsoft.EntityFrameworkCore;
using ProjetoFinalAPI.Domain.Entities;
using ProjetoFinalAPI.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinalAPI.Repository.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext
                (DbContextOptions<SqlServerContext> options)
            : base(options)
        {

        }

        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<Servico> Servico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfissionalMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());
        }
    }
}
