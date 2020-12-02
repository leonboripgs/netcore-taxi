using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class CancelacionViajeEntityConfiguration : IEntityTypeConfiguration<CancelacionViaje>
    {
        public void Configure(EntityTypeBuilder<CancelacionViaje> builder)
        {
            builder.ToTable("cancelaciones_viajes");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.IdCuentaUsuario).HasColumnName("id_cuenta_usuario").IsRequired();
            builder.Property(p => p.IdMotivoCancelacion).HasColumnName("id_motivo_cancelacion").IsRequired();
            builder.Property(p => p.Observaciones).HasColumnName("observaciones");
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta").IsRequired();
            builder.Property(p => p.IdViaje).HasColumnName("id_viaje").IsRequired();

            builder.HasOne(cv => cv.Viaje)
                .WithMany(v => v.CancelacionesViaje)
                .HasForeignKey(fk => fk.IdViaje);

            builder.HasOne(cv => cv.CuentaUsuario)
                .WithMany(cu => cu.CancelacionesViajes)
                .HasForeignKey(fk => fk.IdCuentaUsuario);

            builder.HasOne(cv => cv.MotivoCancelacion)
                .WithMany(mc => mc.CancelacionesViajes)
                .HasForeignKey(fk => fk.IdMotivoCancelacion);
        }
    }
}
