using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class MunicipioEntityConfiguration : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("cat_municipios")
                    .HasOne(d => d.Entidad)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(p => p.EntidadId);

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("cve_muni");
            builder.Property(p => p.EntidadId).HasColumnName("cve_entidad").IsRequired();
            builder.Property(p => p.Nombre).HasColumnName("nombre_muni").IsRequired();
        }
    }
}
