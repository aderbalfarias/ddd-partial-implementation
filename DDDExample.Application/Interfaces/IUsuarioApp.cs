using DDDExample.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDExample.Application.Interfaces
{
    public interface IUsuarioApp : IAppBase<Usuario>
    {
        IEnumerable<Usuario> GetUsuariosPaging(Pagination paginar);
        Task<IEnumerable<Usuario>> GetUsuariosPagingAsync(Pagination paginar);
        Usuario Login(string user, string password);
        Usuario RecuperarSenha(string email);
        void ResetSenha(string login, string codRecover, string newPassword);
        void EditSenha(int userId, string password, string newPassword);
        string GetSenha(int usuarioId);
        object GetPermissoes(int perfilId);
        string GetCodigoRecover();
    }
}
