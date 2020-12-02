using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class ViajeEntityConfiguration : IEntityTypeConfiguration<Viaje>
    {
        public void Configure(EntityTypeBuilder<Viaje> builder)
        {
            builder.ToTable("viajes");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.LatitudOrigen).HasColumnName("latitud_origen").HasMaxLength(50).IsRequired();
            builder.Property(p => p.LongitudOrigen).HasColumnName("longitud_origen").HasMaxLength(50).IsRequired();
            builder.Property(p => p.LatitudDestino).HasColumnName("latitud_destino").HasMaxLength(50).IsRequired();
            builder.Property(p => p.LongitudDestino).HasColumnName("longitud_destino").HasMaxLength(50).IsRequired();
            builder.Property(p => p.EstatusViajeId).HasColumnName("id_estatus_viaje").IsRequired();
            builder.Property(p => p.HoraInicio).HasColumnName("hora_inicio");
            builder.Property(p => p.HoraFin).HasColumnName("hora_fin");
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta").IsRequired();
            builder.Property(p => p.UltimaModificacion).HasColumnName("ultima_modificacion");

            builder.HasOne(v => v.EstatusViaje)
                .WithMany(s => s.Viajes)
                .HasForeignKey(fk => fk.EstatusViajeId);

            builder.Ignore(p => p.CancelacionesViaje);
            builder.Ignore(p => p.ViajesCliente);
            builder.Ignore(p => p.ViajesConductor);
        }
    }
}