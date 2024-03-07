using Microsoft.AspNetCore.Mvc;

namespace Aplicacao_Interativa.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
