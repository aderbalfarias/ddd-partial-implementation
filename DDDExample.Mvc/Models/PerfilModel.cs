using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDDExample.Mvc.Models
{
    public class PerfilModel
    {
        [Key]
        public int PerfilId { get; set; }

        [DisplayName(@"Perfil")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        
        public virtual IEnumerable<UsuarioModel> Usuario { get; set; }
    }
}