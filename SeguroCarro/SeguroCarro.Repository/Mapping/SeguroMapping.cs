using SeguroCarro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeguroCarro.Repository.Mapping
{
    public class SeguroMapping : IEntityTypeConfiguration<Seguro>
    {
        public void Configure(EntityTypeBuilder<Seguro> builder)
        {
            builder.ToTable("SEGURO");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(i => i.PrecoSeguro)
                .HasColumnName("PRECOSEGURO");

            builder.Property(i => i.SeguradoId)
               .HasColumnName("SEGURADOID")
               .IsRequired();

            builder.Property(i => i.CarroId)
               .HasColumnName("CARROID")
               .IsRequired();           

            builder.HasOne(i => i.Segurado)
                   .WithMany().HasForeignKey(fk => fk.SeguradoId);

            builder.HasOne(c => c.Carro).WithMany()
               .HasForeignKey(fk => fk.CarroId);           
        }
    }
}
