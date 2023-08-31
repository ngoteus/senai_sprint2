using Microsoft.AspNetCore.Mvc;

namespace webapi.filmes.manha.Domains
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
