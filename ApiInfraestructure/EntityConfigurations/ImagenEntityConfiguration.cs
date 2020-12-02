using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class ImagenEntityConfiguration : IEntityTypeConfiguration<Imagen>
    {
        public void Configure(EntityTypeBuilder<Imagen> builder)
        {
            builder.ToTable("imagenes");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Image).HasColumnName("image").IsRequired();
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta").IsRequired();
            builder.Property(p => p.UltimaModificacion).HasColumnName("ultima_modificacion");
            builder.Property(p => p.NombreImagen).HasColumnName("filename");

            builder.Ignore(p => p.Usuarios);
            builder.Ignore(p => p.Documentos);
        }
    }
}