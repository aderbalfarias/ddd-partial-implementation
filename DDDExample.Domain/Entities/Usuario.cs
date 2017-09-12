using System;

namespace DDDExample.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public int PerfilId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public DateTime? UltimoAcesso { get; set; }

        public DateTime DataCadastro { get; set; }

        public string CodigoRecover { get; set; }

        public bool Ativo { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}
