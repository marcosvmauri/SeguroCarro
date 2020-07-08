using SeguroCarro.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using SeguroCarro.Domain.Models;

namespace SeguroCarro.Repository.Context
{
    public class SeguroCarroContext : DbContext
    {
        public SeguroCarroContext(DbContextOptions<SeguroCarroContext> options) : base(options) { ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; }
        public SeguroCarroContext() { ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarroMapping());
            modelBuilder.ApplyConfiguration(new SeguradoMapping());
            modelBuilder.ApplyConfiguration(new SeguroMapping());
        }

        public virtual DbSet<Carro> Carros { get; set; }
        public virtual DbSet<Seguro> Seguros { get; set; }
        public virtual DbSet<Segurado> Segurados { get; set; }
    }
}
