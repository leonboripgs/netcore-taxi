using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class EntidadEntityConfiguration : IEntityTypeConfiguration<Entidad>
    {
        public void Configure(EntityTypeBuilder<Entidad> builder)
        {
            builder.ToTable("cat_entidades")
                    .HasOne(d => d.Pais)
                    .WithMany(p => p.Entidades)
                    .HasForeignKey(p => p.ClavePais);

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("cve_entidad");
            builder.Property(p => p.ClavePais).HasColumnName("id_pais").IsRequired();
            builder.Property(p => p.Nombre).HasColumnName("nom_entidad").IsRequired();
            builder.Property(p => p.Abreviacion).HasColumnName("abrevia").IsRequired();
        }
    }
}
