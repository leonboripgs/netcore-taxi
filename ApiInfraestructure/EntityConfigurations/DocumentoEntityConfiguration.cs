using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class DocumentoEntityConfiguration : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.ToTable("documentos");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.TipoDocumentoId).HasColumnName("id_tipo").IsRequired();
            builder.Property(p => p.Referencia).HasColumnName("referencia").HasMaxLength(150);
            builder.Property(p => p.Vigencia).HasColumnName("vigencia");
            builder.Property(p => p.CuentaUsuarioId).HasColumnName("id_cuenta");
            builder.Property(p => p.VehiculoId).HasColumnName("id_vehiculo");
            builder.Property(p => p.ImagenId).HasColumnName("id_imagen");

            builder.HasOne(d => d.TipoDocumento)
                .WithMany(td => td.Documentos)
                .HasForeignKey(fk => fk.TipoDocumentoId);

            builder.HasOne(d => d.Imagen)
                .WithMany(i => i.Documentos)
                .HasForeignKey(fk => fk.ImagenId);

            builder.HasOne(d => d.CuentaUsuario)
                .WithMany(cu => cu.Documentos)
                .HasForeignKey(fk => fk.CuentaUsuarioId);
        }
    }
}