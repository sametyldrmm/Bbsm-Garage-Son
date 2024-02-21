using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bbsm_Garage_Son.Controllers
{
    public class BizeUlasinController : Controller
    {
        // [Authorize(Roles ="Standart")]
        [Authorize(Policy = "RequireStandartRole")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
