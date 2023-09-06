using Microsoft.AspNetCore.Mvc;

namespace senai.inlock.webApi_.Controller
{
    public class EstudioController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
