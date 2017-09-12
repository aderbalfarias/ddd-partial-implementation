using System.Collections.Generic;
using System.Threading.Tasks;
using DDDExample.Application.Interfaces;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Interfaces.Services;

namespace DDDExample.Application.App
{
    public class UsuarioApp : AppBase<Usuario>, IUsuarioApp
    {
        #region Fields

        private readonly IUsuarioService _usuarioService;

        #endregion

        #region Constructors

        public UsuarioApp(IUsuarioService usuarioService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        #endregion
        
        #region Methods

        public IEnumerable<Usuario> GetUsuariosPaging(Pagination paginar)
        {
            return _usuarioService.GetUsuariosPaging(paginar);
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosPagingAsync(Pagination paginar)
        {
            return await _usuarioService.GetUsuariosPagingAsync(paginar);
        }

        public Usuario Login(string user, string password)
        {
            return _usuarioService.Login(user, password);
        }

        public Usuario RecuperarSenha(string email)
        {
            return _usuarioService.RecuperarSenha(email);
        }

        public void ResetSenha(string login, string codRecover, string newPassword)
        {
            _usuarioService.ResetSenha(login, codRecover, newPassword);
        }

        public void EditSenha(int userId, string password, string newPassword)
        {
            _usuarioService.EditSenha(userId, password, newPassword);
        }

        public string GetSenha(int usuarioId)
        {
            return _usuarioService.GetSenha(usuarioId);
        }

        public object GetPermissoes(int perfilId)
        {
            return _usuarioService.GetPermissoes(perfilId);
        }

        public string GetCodigoRecover()
        {
            return _usuarioService.GetCodigoRecover();
        }

        #endregion
    }
}
