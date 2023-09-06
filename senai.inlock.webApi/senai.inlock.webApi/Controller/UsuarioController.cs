using Microsoft.AspNetCore.Mvc;

namespace senai.inlock.webApi_.Controller
{
    public class UsuarioController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
