using Microsoft.AspNetCore.Mvc;

namespace Minigames.Api.Controllers
{
    public class HangmanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
