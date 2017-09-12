using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Interfaces.Repositories;
using DDDExample.Domain.Interfaces.Services;

namespace DDDExample.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        #region Fields

        private readonly IUsuarioRepository _usuarioRepository;

        #endregion

        #region Constructors

        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        #endregion

        #region Methods

        public IEnumerable<Usuario> GetUsuariosPaging(Pagination paginar)
        {
            return _usuarioRepository.GetUsuariosPaging(paginar);
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosPagingAsync(Pagination paginar)
        {
            return await _usuarioRepository.GetUsuariosPagingAsync(paginar);
        }

        public Usuario Login(string user, string password)
        {
            return _usuarioRepository.Login(user, CriptografarSenha(password), password);
        }

        public Usuario RecuperarSenha(string email)
        {
            return _usuarioRepository.RecuperarSenha(email, GetCodigoRecover(), CriptografarSenha(GetCodigoRecover()));
        }

        public void ResetSenha(string login, string codRecover, string newPassword)
        {
            _usuarioRepository.ResetSenha(login, codRecover, CriptografarSenha(newPassword));
        }

        public void EditSenha(int userId, string password, string newPassword)
        {
            _usuarioRepository.EditSenha(userId, CriptografarSenha(password), CriptografarSenha(newPassword));
        }

        public string GetSenha(int usuarioId)
        {
            return _usuarioRepository.GetSenha(usuarioId);
        }

        public object GetPermissoes(int perfilId)
        {
            return _usuarioRepository.GetPermissoes(perfilId);
        }

        public string GetCodigoRecover()
        {
            var randNum = new Random();

            int i;
            var codigoRecover = "X";
            for (i = 0; i < 8; i++)
                codigoRecover += randNum.Next(9);

            return codigoRecover;
        }

        #endregion

        #region Private Methods

        private string CriptografarSenha(string senha)
        {
            return Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(new UTF32Encoding().GetBytes(senha)));
        }

        #endregion
    }
}