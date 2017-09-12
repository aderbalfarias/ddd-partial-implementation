using System.Data.Entity.ModelConfiguration;
using DDDExample.Domain.Entities;

namespace DDDExample.Infrastructure.Data.EntityConfig
{
    public class PerfilConfiguration : EntityTypeConfiguration<Perfil>
    {
        public PerfilConfiguration()
        {
            HasKey(k => k.PerfilId);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
