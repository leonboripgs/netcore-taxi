using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
public class TipoCuentaEntityConfiguration : IEntityTypeConfiguration<TipoCuenta>
{
public void Configure(EntityTypeBuilder<TipoCuenta> builder)
{
builder.ToTable("cat_tipos_cuenta");

builder.HasKey(k => k.Id);
builder.Property(p => p.Id).HasColumnName("id").IsRequired();
builder.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(25).IsRequired();
builder.Property(p => p.Descripcion).HasColumnName("descripcion").HasMaxLength(250);
builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta").IsRequired();
builder.Property(p => p.UltimaActualizacion).HasColumnName("ultima_actualizacion");
}
}
}
