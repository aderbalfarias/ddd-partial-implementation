using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using DDDExample.Domain.Entities;

namespace DDDExample.Infrastructure.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(k => k.UsuarioId);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Email") { IsUnique = true }));

            Property(p => p.Login)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Login") { IsUnique = true }));

            Property(p => p.Senha)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.CodigoRecover)
                .IsOptional()
                .HasMaxLength(50);

            ////IEnumerable
            //HasRequired(r => r.Perfil)
            //    .WithMany()
            //    .HasForeignKey(f => f.PerfilId);
            
            //ICollection
            HasRequired(r => r.Perfil)
                .WithMany(w => w.Usuario)
                .HasForeignKey(f => f.PerfilId)
                .WillCascadeOnDelete(false);
        }
    }
}
