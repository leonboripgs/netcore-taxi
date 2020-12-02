using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(255).IsRequired();
            builder.Property(p => p.ApellidoPaterno).HasColumnName("apellido_paterno").HasMaxLength(200).IsRequired();
            builder.Property(p => p.ApellidoMaterno).HasColumnName("apellido_materno").HasMaxLength(200);
            builder.Property(p => p.FechaNacimiento).HasColumnName("fecha_nacimiento").IsRequired();
            builder.Property(p => p.IdMunicipio).HasColumnName("id_municipio").HasMaxLength(3).IsRequired();
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta").IsRequired();
            builder.Property(p => p.UltimaModificacion).HasColumnName("ultima_modificacion");
            builder.Property(p => p.ImagenId).HasColumnName("id_image");
            builder.Property(p => p.Telefono).HasColumnName("telefono").HasMaxLength(10).IsRequired();
            builder.Property(p => p.IdEntidad).HasColumnName("id_entidad").HasMaxLength(2).IsRequired();
            
            builder.Ignore(p => p.Municipio);
            builder.Ignore(p => p.Cuentas);

            builder.HasOne(u => u.Imagen)
                     .WithMany(i => i.Usuarios)
                     .HasForeignKey(fk => fk.ImagenId);
        }
    }
}
