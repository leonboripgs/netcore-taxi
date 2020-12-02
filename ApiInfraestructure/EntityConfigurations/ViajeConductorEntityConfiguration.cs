using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class ViajeConductorEntityConfiguration : IEntityTypeConfiguration<ViajeConductor>
    {
        public void Configure(EntityTypeBuilder<ViajeConductor> builder)
        {
            builder.ToTable("historial_viajes_conductores");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.IdConductor).HasColumnName("id_conductor").IsRequired();
            builder.Property(p => p.IdViaje).HasColumnName("id_viaje").IsRequired();
            builder.Property(p => p.KmRecorridos).HasColumnName("km_recorridos");
            builder.Property(p => p.Tarifa).HasColumnName("tarifa");
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta").IsRequired();

            builder.HasOne(hvc => hvc.Conductor)
                .WithMany(c => c.ViajesConductor)
                .HasForeignKey(fk => fk.IdConductor);

            builder.HasOne(hvc => hvc.Viaje)
                .WithMany(v => v.ViajesConductor)
                .HasForeignKey(fk => fk.IdViaje);
        }
    }
}