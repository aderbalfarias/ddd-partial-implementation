using DDDExample.Application.Interfaces;
using DDDExample.Domain.Entities;
using DDDExample.Infrastructure.CrossCutting.Complement.Extensions;
using DDDExample.Mvc.Controllers.Shared;
using DDDExample.Mvc.Models;
using DDDExample.Mvc.Models.Shared;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace DDDExample.Mvc.Controllers
{
    public class LoginController : CustomController
    {
        #region Fields

        private readonly IUsuarioApp _usuarioApp;
        private readonly IEmailApp _emailApp;

        private IAuthenticationManager AuthenticationManager => HttpContext
            .GetOwinContext().Authentication;

        #endregion

        #region Constructors

        public LoginController(IUsuarioApp usuarioApp, IEmailApp emailApp)
        {
            _usuarioApp = usuarioApp;
            _emailApp = emailApp;
        }

        #endregion

        #region Actions 

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!AuthenticationManager.User.Identity.IsAuthenticated)
                return View();

            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /Login/LogIn
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[CustomAuthorize("Login", "LogIn")]
        public ActionResult LogIn(LoginModel model)
        {
            try
            {
                LogAcesso(model.Login);
                var user = _usuarioApp.Login(model.Login, model.Password);
                if (user != null)
                {
                    if (user.UltimoAcesso == null || user.CodigoRecover != null)
                        return RedirectToAction("ChangePassword", new { @login = user.Login, @codRecover = user.CodigoRecover });

                    SignInAsync(user, model.RememberMe);

                    return RedirectToAction("Index");
                }

                ShowMessageDialog("Usuário e/ou senha inválidos", Message.MessageKind.Error);
            }
            catch (Exception exception)
            {
                ShowMessageDialog("Ocorreu um erro ao tentar efetuar login!", exception);
            }

            return View("Index");
        }

        public ActionResult Logoff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RecoverPassword(LoginModel model)
        {
            try
            {
                var usuario = _usuarioApp.RecuperarSenha(model.Email);

                if (usuario != null)
                {
                    var modelEmail = new EmailModel
                    {
                        From = "teste@teste.com.br",
                        To = new List<string> { model.Email },
                        Subject = "Recuperação de Senha",
                        Body =
                            $"Caro(a) {usuario.Nome},<br><br> Conforme solicitado segue o dados para recuperação de senha, " +
                            $"<br> Login: {usuario.Login}<br> Código de Recuperação: {usuario.CodigoRecover}"
                    };

                    _emailApp.SendEmail(modelEmail.Cast<Email>());
                    ShowMessageDialog("E-mail enviado!", Message.MessageKind.Success);
                }
                else
                {
                    ShowMessageDialog("E-mail não encontrado!", Message.MessageKind.Warning);
                }
            }
            catch (Exception exception)
            {
                ShowMessageDialog("Ocorreu um erro ao tentar enviar o e-mail de recuperação da senha!", exception);
            }

            return View("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(LoginModel model)
        {
            try
            {
                _usuarioApp.ResetSenha(model.Login, model.CodigoRecover, model.NewPassword);
                ShowMessageDialog("Senha alterada!", Message.MessageKind.Success);
            }
            catch (Exception exception)
            {
                ShowMessageDialog("Ocorreu um erro ao tentar alterar a senha!", exception);
            }

            return View("Index");
        }

        [AllowAnonymous]
        public ViewResult ChangePassword(string login, string codRecover)
        {
            var model = new LoginModel
            {
                Login = login,
                CodigoRecover = codRecover
            };

            return View(model);
        }

        public ActionResult EditPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPassword(LoginModel model)
        {
            try
            {
                _usuarioApp.EditSenha(CurrentUser.UserId, model.Password, model.NewPassword);
                ShowMessageDialog("Senha alterada!", Message.MessageKind.Success);

                return RedirectToAction("Logoff");
            }
            catch (Exception exception)
            {
                ShowMessageDialog("Não foi possível alterar a senha!", exception);
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        public ActionResult SessionExpirada()
        {
            ShowMessageDialog("Sua sessão expirou!", Message.MessageKind.Warning);
            return RedirectToAction("Logoff");
        }

        #endregion

        #region Private Methods

        private void SignInAsync(dynamic user, bool isPersistent)
        {
            var clains = new List<Claim>
            {
                new Claim(ClaimTypes.Authentication, user.Login),
                new Claim(ClaimTypes.NameIdentifier, user.Login),
                new Claim(ClaimTypes.Role, user.Perfil.Descricao),
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("PerfilId", user.PerfilId.ToString(CultureInfo.InvariantCulture)),
                new Claim("UsuarioId", user.UsuarioId.ToString(CultureInfo.InvariantCulture))
            };

            var identity = new ClaimsIdentity(clains, DefaultAuthenticationTypes.ApplicationCookie);
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);
        }

        public void LogAcesso(string login)
        {
            var description = $"{DateTime.Now} | IP Fixo:{Request.ServerVariables["HTTP_X_FORWARDED_FOR"]} | IP Virtual: {Request.UserHostAddress} | Host Name: {Request.UserHostName}";

            var local = Server.MapPath(@"~/Files/LogAcesso");

            if (!Directory.Exists(local))
                Directory.CreateDirectory(local);

            var fileName = Path.Combine(local, login + ".txt");

            using (var file = new StreamWriter(fileName, true))
            {
                file.WriteLine(description);
            }
        }

        #endregion
    }
}
