using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class ModeloEntityConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("cat_modelos_vehiculos");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(200);
            builder.Property(p => p.IdMarca).HasColumnName("id_marca");
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta");
            builder.Property(p => p.UltimaModificacion).HasColumnName("ultima_modificacion");

            builder.HasOne(p => p.Marca)
                .WithMany(m => m.Modelos)
                .HasForeignKey(fk => fk.IdMarca);

            builder.Ignore(p => p.Vehiculos);
        }
    }
}
