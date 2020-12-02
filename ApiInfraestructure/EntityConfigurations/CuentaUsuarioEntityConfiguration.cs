using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApiInfraestructure.EntityConfigurations
{
    public class CuentaUsuarioEntityConfiguration : IEntityTypeConfiguration<CuentaUsuario>
    {
        public void Configure(EntityTypeBuilder<CuentaUsuario> builder)
        {
            builder.ToTable("cuentas_usuario");
            
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.IdUsuario).HasColumnName("id_usuario").IsRequired();
            builder.Property(p => p.Password).HasColumnName("password").HasMaxLength(150).IsRequired();
            builder.Property(p => p.IdTipoCuenta).HasColumnName("id_tipo_cuenta").IsRequired();
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta").IsRequired();
            builder.Property(p => p.UltimaModificacion).HasColumnName("ultima_modificacion");
            builder.Property(p => p.Email).HasColumnName("email");
            builder.Property(p => p.Domicilio).HasMaxLength(1000).HasColumnName("domicilio");
            builder.Property(p => p.EnServicio).HasMaxLength(1000).HasColumnName("en_servicio");

            builder.HasOne(p => p.Usuario)
                .WithMany(d => d.Cuentas)
                .HasForeignKey(fk => fk.IdUsuario);

            builder.HasOne(cu => cu.TipoCuenta)
                .WithMany(tc => tc.CuentasUsuario)
                .HasForeignKey(fk => fk.IdTipoCuenta);

            builder.Ignore(p => p.Documentos);
            builder.Ignore(p => p.Vehiculos);
        }
    }
}
