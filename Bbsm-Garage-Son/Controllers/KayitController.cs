using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bbsm_Garage_Son.Controllers
{
    public class KayitController : Controller
    {
        [Authorize(Policy = "RequireStandartRole")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
