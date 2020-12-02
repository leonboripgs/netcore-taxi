using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiInfraestructure.EntityConfigurations
{
    public class MotivoCancelacionEntityConfiguration : IEntityTypeConfiguration<MotivoCancelacion>
    {
        public void Configure(EntityTypeBuilder<MotivoCancelacion> builder)
        {
            builder.ToTable("cat_motivos_cancelacion");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Motivo).HasColumnName("motivo").HasMaxLength(500).IsRequired();
            builder.Property(p => p.IdTipoCuenta).HasColumnName("id_tipo_cuenta").IsRequired();
            builder.Property(p => p.FechaAlta).HasColumnName("fecha_alta").IsRequired();
            builder.Property(p => p.UltimaModificacion).HasColumnName("ultima_modificacion");

            builder.HasOne(mb => mb.TipoCuenta)
                .WithMany(tc => tc.MotivosCancelacion)
                .HasForeignKey(fk => fk.IdTipoCuenta);
        }
    }
}