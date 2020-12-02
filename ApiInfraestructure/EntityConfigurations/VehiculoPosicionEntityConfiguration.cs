using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class VehiculoPosicionEntityConfiguration : IEntityTypeConfiguration<VehiculoPosicion>
    {
        public void Configure(EntityTypeBuilder<VehiculoPosicion> builder)
        {
            builder.ToTable("track_on_demand");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.IdCuentaUsuario).HasColumnName("id_cuenta");
            builder.Property(p => p.Latitud).HasColumnName("latitud").HasMaxLength(20);
            builder.Property(p => p.Longitud).HasColumnName("longitud").HasMaxLength(20);
            builder.Property(p => p.UltimaActualizacion).HasColumnName("ultima_actualizacion");
            /*
            builder.HasOne(v => v.CuentaUsuario)
                .WithMany(cu => cu.VehiculoPosicion)
                .HasForeignKey(fk => fk.IdCuentaUsuario);
                */
            /*
            builder.HasOne(v => v.Modelo)
                .WithMany(m => m.VehiculoPosicion)
                .HasForeignKey(fk => fk.IdModelo);

            builder.HasOne(v => v.CuentaUsuario)
                .WithMany(cu => cu.VehiculoPosicion)
                .HasForeignKey(fk => fk.IdCuentaUsuario);
            */
        }
    }
}