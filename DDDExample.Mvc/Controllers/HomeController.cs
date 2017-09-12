using DDDExample.Mvc.Controllers.Shared;
using System.Web.Mvc;

namespace DDDExample.Mvc.Controllers
{
    public class HomeController : CustomController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}