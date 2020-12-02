using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class ViajeUsuarioEntityConfiguration : IEntityTypeConfiguration<ViajeUsuario>
    {
        public void Configure(EntityTypeBuilder<ViajeUsuario> builder)
        {
            builder.ToTable("historial_viajes_usuarios");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ClienteId).HasColumnName("id_cliente").IsRequired();
            builder.Property(p => p.ViajeId).HasColumnName("id_viaje").IsRequired();
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta").IsRequired();

            builder.HasOne(hvc => hvc.Cliente)
                .WithMany(c => c.ViajesCliente)
                .HasForeignKey(fk => fk.ClienteId);

            builder.HasOne(hvc => hvc.Viaje)
                .WithMany(v => v.ViajesCliente)
                .HasForeignKey(fk => fk.ViajeId);
        }
    }
}