using SeguroCarro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeguroCarro.Repository.Mapping
{
    public class SeguradoMapping : IEntityTypeConfiguration<Segurado>
    {
        public void Configure(EntityTypeBuilder<Segurado> builder)
        {
            builder.ToTable("SEGURADO");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Nome)
                .HasColumnName("NOME")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Cpf)
                .HasColumnName("CPF")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(i => i.Idade)
                .HasColumnName("IDADE")
                .IsRequired();        
        }
    }
}
