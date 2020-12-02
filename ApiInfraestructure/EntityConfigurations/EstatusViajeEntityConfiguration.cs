using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class EstatusViajeEntityConfiguration : IEntityTypeConfiguration<EstatusViaje>
    {
        public void Configure(EntityTypeBuilder<EstatusViaje> builder)
        {
            builder.ToTable("cat_estatus_viajes");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descripcion).HasColumnName("descripcion").HasMaxLength(250);
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta").IsRequired();
            builder.Property(p => p.UltimaModificacion).HasColumnName("ultima_modificacion");

            builder.Ignore(p => p.Viajes);
        }
    }
}