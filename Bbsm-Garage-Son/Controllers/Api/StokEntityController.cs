using Microsoft.AspNetCore.Mvc;
using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Bbsm_Garage_Son.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokEntityController : ControllerBase
    {
        private readonly StokService _stokService;

        public StokEntityController(StokService stokService)
        {
            _stokService = stokService;
        }

        // [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetStokList(int id) // user id
        {
            var card = _stokService.GetStokById(id);
            if (card == null)
            {
                return Ok();
            }
            return Ok(card);
        }

        // [Authorize]
        [HttpPost]
        public IActionResult AddCard([FromBody] StokEntity Stok)
        {
            Console.WriteLine(Stok);
            // Stok.Date = DateTime.UtcNow;
            _stokService.AddStok(Stok);
            return Ok(Stok);
        }

        // [Authorize]
        [HttpPut]
        public IActionResult UpdateCard([FromBody] StokEntity card)
        {
            _stokService.UpdateStok(card);
            return Ok();
        }


        [HttpPost("updateoradd")]
        public IActionResult UpdateOrAddCard(int id,[FromBody] StokEntity card)
        {
            _stokService.UpdateOrAdd(id,card);
            return Ok();
        }

        // [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            _stokService.DeleteStok(id);
            return NoContent();
        }
    }
}
