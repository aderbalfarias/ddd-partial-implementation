using System;
using System.Security.Claims;

namespace DDDExample.Mvc.Models.Shared
{
    public class AppUser : ClaimsPrincipal
    {
        public AppUser(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        public string CompanyUser => FindFirst(ClaimTypes.NameIdentifier).Value;

        public string Country => FindFirst(ClaimTypes.Country).Value ?? string.Empty;

        public string MailUser => FindFirst(ClaimTypes.Email).Value;

        public string Perfil => FindFirst(ClaimTypes.Role).Value;

        public int PerfilId => Convert.ToInt32(FindFirst("PerfilId").Value);
        public int UserId => Convert.ToInt32(FindFirst("UsuarioId").Value);
    }
}