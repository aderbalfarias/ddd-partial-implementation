using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Interfaces.Repositories;

namespace DDDExample.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        #region Fields

        #endregion

        #region Methods

        public IEnumerable<Usuario> GetUsuariosPaging(Pagination paginar)
        {
            return _context.Usuario
                .Include(i => i.Perfil)
                .OrderBy(o => o.Nome)
                .Skip(paginar.SkipPagina(paginar))
                .Take(paginar.QtdeItensPagina)
                .ToList();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosPagingAsync(Pagination paginar)
        {
            return await Task.Run(() =>
                _context.Usuario
                .Include(i => i.Perfil)
                .OrderBy(o => o.Nome)
                .Skip(paginar.SkipPagina(paginar))
                .Take(paginar.QtdeItensPagina));
        }

        public Usuario Login(string user, string password, string codRecover)
        {
            var usuario = _context.Usuario
                .Include(i => i.Perfil)
                .FirstOrDefault(u => u.Ativo && u.Login == user && u.Senha == password);

            if (usuario == null)
                return _context.Usuario
                    .Include(i => i.Perfil)
                    .FirstOrDefault(u => u.Ativo && u.Login == user && u.Senha == codRecover && u.CodigoRecover == codRecover);

            usuario.UltimoAcesso = DateTime.Now;
            _context.SaveChanges();
            
            return usuario;
        }

        public Usuario RecuperarSenha(string email, string codigoRecover, string passRecover)
        {
            var usuario = _context.Usuario
                .FirstOrDefault(u => u.Email == email);

            if (usuario == null)
                return null;

            usuario.CodigoRecover = codigoRecover;
            usuario.Senha = passRecover;

            _context.SaveChanges();

            return usuario;
        }

        public void ResetSenha(string login, string codRecover, string newPassword)
        {
            var usuario = _context.Usuario
                .Single(u => u.Login == login && u.CodigoRecover == codRecover);

            usuario.CodigoRecover = null;
            usuario.Senha = newPassword;
            _context.SaveChanges();
        }

        public void EditSenha(int userId, string password, string newPassword)
        {
            var user = _context.Usuario
                .Single(u => u.UsuarioId == userId && u.Senha == password);

            user.Senha = newPassword;
            _context.SaveChanges();
        }

        public string GetSenha(int usuarioId)
        {
            return _context.Usuario
                .First(u => u.UsuarioId == usuarioId).Senha;
        }

        public object GetPermissoes(int perfilId)
        {
            return new
            {
                PerfilId = perfilId,
                Menus = ""
            };
        }

        #endregion
    }
}
