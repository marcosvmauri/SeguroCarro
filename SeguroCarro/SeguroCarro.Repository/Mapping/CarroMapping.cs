using SeguroCarro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeguroCarro.Repository.Mapping
{
    public class CarroMapping : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.ToTable("CARRO");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.ValorCarro)
                .HasColumnName("VALORCARRO");

            builder.Property(c => c.Marca)
                .HasColumnName("MARCA")
                .HasMaxLength(100);
        }
    }
}
