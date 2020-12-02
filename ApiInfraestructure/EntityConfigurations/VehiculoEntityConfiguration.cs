using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class VehiculoEntityConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("vehiculos");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.IdModelo).HasColumnName("id_modelo");
            builder.Property(p => p.IdCuentaUsuario).HasColumnName("id_cuenta_usuario");
            builder.Property(p => p.Anio).HasColumnName("anio");
            builder.Property(p => p.Color).HasColumnName("color").HasMaxLength(50);
            builder.Property(p => p.Placa).HasColumnName("placa").HasMaxLength(8);
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta");
            builder.Property(p => p.UltimaModificacion).HasColumnName("ultima_modificacion");

            builder.HasOne(v => v.Modelo)
                .WithMany(m => m.Vehiculos)
                .HasForeignKey(fk => fk.IdModelo);

            builder.HasOne(v => v.CuentaUsuario)
                .WithMany(cu => cu.Vehiculos)
                .HasForeignKey(fk => fk.IdCuentaUsuario);
        }
    }
}