using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DDDExample.Domain.Entities;

namespace DDDExample.Mvc.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = @"Campo obrigatório")]
        [DisplayName(@"Perfil")]
        public int PerfilId { get; set; }

        [Required(ErrorMessage = @"Campo obrigatório")]
        [MaxLength(100, ErrorMessage = @"Limite máximo de 100 caracteres atingido")]
        [MinLength(2, ErrorMessage = @"Limite mínimo de 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = @"Campo obrigatório")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = @"Endereço de e-mail inválido")]
        [DisplayName(@"E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = @"Campo obrigatório")]
        public string Login { get; set; }

        public string Senha { get; set; }

        [DisplayName(@"Último Acesso")]
        public DateTime? UltimoAcesso { get; set; }

        [DisplayName(@"Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        public string CodigoRecover { get; set; }

        [Required(ErrorMessage = @"Campo obrigatório")]
        public bool Ativo { get; set; }

        //public virtual PerfilModel Perfil { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}