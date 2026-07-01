using Microsoft.AspNetCore.Mvc;

namespace Minigames.Api.Controllers
{
    public class LeaderboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
