using DDDExample.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDDExample.Mvc.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = @"Required Field")]
        [DisplayName(@"Access Profile")]
        public int PerfilId { get; set; }

        [Required(ErrorMessage = @"Required Field")]
        [MaxLength(100, ErrorMessage = @"Limite máximo de 100 caracteres atingido")]
        [MinLength(2, ErrorMessage = @"Limite mínimo de 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = @"Required Field")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = @"Endereço de e-mail inválido")]
        [DisplayName(@"Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = @"Required Field")]
        [DisplayName(@"User")]
        public string Login { get; set; }

        [DisplayName(@"Password")]
        public string Senha { get; set; }

        [DisplayName(@"Last Access")]
        public DateTime? UltimoAcesso { get; set; }

        [DisplayName(@"Create Date")]
        public DateTime DataCadastro { get; set; }

        [DisplayName(@"Recover Code")]
        public string CodigoRecover { get; set; }

        [Required(ErrorMessage = @"Required Field")]
        [DisplayName(@"Active")]
        public bool Ativo { get; set; }

        //public virtual PerfilModel Perfil { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}