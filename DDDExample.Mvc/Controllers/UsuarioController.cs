using DDDExample.Application.Interfaces;
using DDDExample.Domain.Entities;
using DDDExample.Infrastructure.CrossCutting.Complement.Extensions;
using DDDExample.Mvc.Controllers.Shared;
using DDDExample.Mvc.Models;
using DDDExample.Mvc.Models.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DDDExample.Mvc.Controllers
{
    public class UsuarioController : CustomController
    {
        #region Fields

        private readonly IUsuarioApp _usuarioApp;
        private readonly IPerfilApp _perfilApp;
        private readonly IEmailApp _emailApp;

        #endregion

        #region Constructors

        public UsuarioController(IUsuarioApp usuarioApp, IPerfilApp perfilApp, IEmailApp emailApp)
        {
            _usuarioApp = usuarioApp;
            _perfilApp = perfilApp;
            _emailApp = emailApp;
        }

        #endregion

        #region Actions

        //// GET: Usuario
        //[Authorize(Roles = "Administrador")]
        ////[IsAuthorize("Usuario", "Index")]
        //public ActionResult Index(int idPag = 0)
        //{
        //    try
        //    {
        //        var paginar = new Pagination
        //        {
        //            PaginaAtual = idPag
        //        };

        //        var model = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioModel>>(_usuarioApp.GetUsuariosPaging(ref paginar));

        //        ViewBag.PaginaAtual = paginar.PaginaAtual;
        //        ViewBag.QtdePaginas = paginar.QtdePaginas;

        //        return View(model);
        //    }
        //    catch (Exception e)
        //    {
        //        ShowMessageDialog("Ocorreu um problema ao tentar listar os usuário", e);
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        // GET: Usuario
        [Authorize(Roles = "Administrador")]
        //[IsAuthorize("Usuario", "Index")]
        public async Task<ActionResult> Index(int idPag = 0)
        {
            try
            {

                //var perfilId = CurrentUser.PerfilId;
                //var perfilId = System.Web.HttpContext.Current.GetOwinContext()
                //    .Authentication.User.FindFirst("PerfilId").Value;
                var paginar = new Pagination
                {
                    PaginaAtual = idPag
                };

                var model = _usuarioApp.GetUsuariosPaging(paginar)
                    .CastAll<UsuarioModel>();

                paginar = paginar.CalcularPagination(paginar, await _usuarioApp.CountAsync());
                ViewBag.PaginaAtual = paginar.PaginaAtual;
                ViewBag.QtdePaginas = paginar.QtdePaginas;

                return View(model);
            }
            catch (Exception e)
            {
                ShowMessageDialog("Ocorreu um problema ao tentar listar os usuário", e);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(_perfilApp.GetAll(), "PerfilId", "Descricao");
            return View(new UsuarioModel());
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Senha = _usuarioApp.GetCodigoRecover();
                    model.CodigoRecover = _usuarioApp.GetCodigoRecover();
                    _usuarioApp.Add(model.Cast<Usuario>());

                    try
                    {
                        var modelEmail = new EmailModel
                        {
                            From = "teste@teste.com.br",
                            To = new List<string> { model.Email },
                            Subject = "Workflow - Cadastramento no Portal",
                            Body =
                                $"Caro(a) {model.Nome},<br><br> Foi realizado cadastramento no portal para seu usuário, conforme informações a seguir, " +
                                $"<br> Login: {model.Login}<br> Senha: {model.Senha}"
                        };

                        _emailApp.SendEmail(modelEmail.Cast<Email>());
                    }
                    catch (Exception e)
                    {
                        ShowMessageDialog("Usuário cadastrado, porém ocorreu um erro ao enviar o email", e);
                        return RedirectToAction("Index");
                    }

                    ShowMessageDialog("Usuário cadastrado, e e-mail enviado!", Message.MessageKind.Success);
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                ShowMessageDialog("Ocorreu um problema ao tentar cadastrar usuário", e);
            }

            return RedirectToAction("Index");
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _usuarioApp.GetId(id).Cast<UsuarioModel>();
            ViewBag.PerfilId = new SelectList(_perfilApp.GetAll(), "PerfilId", "Descricao", model.PerfilId);
            return View(model);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Senha = $"{_usuarioApp.GetSenha(model.UsuarioId)}";
                    _usuarioApp.Update(model.Cast<Usuario>());

                    ShowMessageDialog("Usuário Atualizado!", Message.MessageKind.Success);
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                ShowMessageDialog("Ocorreu um problema ao tentar atualizar os dados de usuário", e);
            }

            return RedirectToAction("Index");
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var usuario = _usuarioApp.GetId(id);
                _usuarioApp.Remove(usuario);

                ShowMessageDialog("Usuário Removido!", Message.MessageKind.Success);
            }
            catch (Exception e)
            {
                ShowMessageDialog("Ocorreu um problema ao tentar excluir os dados do usuário", e);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult ListarPermissao(int id)
        {
            var permissoes = _usuarioApp.GetPermissoes(id);

            return Json(permissoes, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
