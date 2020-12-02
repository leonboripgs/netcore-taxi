using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApiInfraestructure.EntityConfigurations
{
    public class CodigoValidacionEntityConfiguration : IEntityTypeConfiguration<CodigoValidacion>
    {
        public void Configure(EntityTypeBuilder<CodigoValidacion> builder)
        {
            builder.ToTable("codigo_verificacion");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Telefono).HasColumnName("telefono").HasMaxLength(10).IsRequired();
            builder.Property(p => p.Codigo).HasColumnName("codigo").HasMaxLength(4).IsRequired();
            builder.Property(p => p.FechaGeneracion).HasColumnName("fecha_generacion").IsRequired();
        }
    }
}
