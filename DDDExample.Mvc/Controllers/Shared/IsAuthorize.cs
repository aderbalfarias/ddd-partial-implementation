using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDDExample.Mvc.Controllers.Shared
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class IsAuthorize : AuthorizeAttribute
    {
        private readonly Ex _list;
        private readonly string _controler;
        private readonly string _action;

        public IsAuthorize(string controler, string action)
        {
            _controler = controler;
            _action = action;

            _list = List();
        }

        public override void OnAuthorization(AuthorizationContext context)
        {
            bool authorized = _list.controller.Contains(_controler)
                && _list.action.Contains(_action) && _list.perfiis.Any(role => HttpContext.Current.User.IsInRole(role));

            //var actions = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => typeof(Controller).IsAssignableFrom(type))
            //    .SelectMany(s => s.GetMethods()
            //        .Select(t => new
            //        {
            //            Controller = s, 
            //            Action = t
            //        }))
            //        .Where(w => w.Action.IsPublic)
            //        .Where(w => w.Action.MemberType == MemberTypes.Method)
            //        .Where(w => w.Action.DeclaringType == w.Controller)
            //        .Where(w => w.Controller.Name != "CustomController")
            //        .Select(s => new
            //        {
            //            Controller = s.Controller.Name,
            //            Action = s.Action.Name,
            //            TypeResult = s.Action.ReturnType.Name,
            //            Family = s.Action.ReflectedType,
            //            x = s.Action.MemberType,
            //            y = s.Action.MethodImplementationFlags,
            //        })
            //        .Distinct()
            //        .OrderBy(o => o.Controller)
            //        .ThenBy(tb => tb.Action)
            //        .ToList();

            if (authorized) return;

            var url = new UrlHelper(context.RequestContext);
            var logonUrl = url.Action("Index", "Login");
            context.Result = new RedirectResult(logonUrl);
        }

        public Ex List()
        {
            return new Ex
            {
                controller = "Usuario",
                action = "Index",
                perfiis = new List<string> { "teste", "admin", "Administrador" }
            };
        }
    }

    public class Ex
    {
        public string controller { get; set; }
        public string action { get; set; }
        public List<string> perfiis { get; set; }
    }
}