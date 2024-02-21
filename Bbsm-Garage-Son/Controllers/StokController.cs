using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bbsm_Garage_Son.Controllers
{
    public class StokController : Controller
    {

        private readonly StokService _stokService;


        public StokController(StokService stokService)
        {
            _stokService = stokService;
        }


        [Authorize(Policy = "RequireStandartRole")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
