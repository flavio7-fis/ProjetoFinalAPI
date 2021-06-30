using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinalAPI.Repository.Mappings
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            //nome da tabela no banco de dados
            builder.ToTable("SERVICO");

            //chave primária da tabela
            //HasKey -> Primary key
            builder.HasKey(s => s.IdServico);

            //mapear os campos da tabela
            builder.Property(s => s.IdServico)
                .HasColumnName("IDSERVICO");

            builder.Property(s => s.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(s => s.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(s => s.Valor)
                .HasColumnName("VALOR")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(s => s.IdProfissional)
                .HasColumnName("IDPROFISSIONAL")
                .IsRequired();

            //mapeamento das chaves estrangeiras
            //Foreign Key (OneToMany)
            builder.HasOne(e => e.Profissional)
                .WithMany(s => s.Servicos)
                .HasForeignKey(e => e.IdProfissional);
        }

    }
}
