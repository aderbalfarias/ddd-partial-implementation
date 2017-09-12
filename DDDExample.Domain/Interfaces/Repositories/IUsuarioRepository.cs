using System.Collections.Generic;
using System.Threading.Tasks;
using DDDExample.Domain.Entities;

namespace DDDExample.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        IEnumerable<Usuario> GetUsuariosPaging(Pagination paginar);
        Task<IEnumerable<Usuario>> GetUsuariosPagingAsync(Pagination paginar);
        Usuario Login(string user, string password, string codRecover);
        Usuario RecuperarSenha(string email, string codigoRecover, string passRecover);
        void ResetSenha(string login, string codRecover, string newPassword);
        void EditSenha(int userId, string password, string newPassword);
        string GetSenha(int usuarioId);
        object GetPermissoes(int perfilId);
    }
}
