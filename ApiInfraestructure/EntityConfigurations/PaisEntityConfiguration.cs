using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class PaisEntityConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("cat_paises");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nombre).HasColumnName("nombre").IsRequired();
        }
    }
}
