using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinalAPI.Repository.Mappings
{
    //Classe para mapear a entidade Profissional (ORM)
    public class ProfissionalMap : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            //nome da tabela
            builder.ToTable("PROFISSIONAL");

            //chave primária na tabela
            //HasKey -> Primary Key
            builder.HasKey(e => e.IdProfissional);

            //mapear cada campo ad tabela
            builder.Property(e => e.IdProfissional)
                .HasColumnName("IDPROFISSIONAL");

            builder.Property(e => e.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(15)
                .IsRequired();
            builder.HasIndex(e => e.Cpf)
                .IsUnique();

            builder.Property(e => e.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
