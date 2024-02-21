using Microsoft.AspNetCore.Mvc;
using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Bbsm_Garage_Son.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardEntitiesController : ControllerBase
    {
        private readonly KartService _kartService;
        private readonly CardTwoState _CardTwoState;

        public CardEntitiesController(KartService kartService,CardTwoState cardTwoState)
        {
            _kartService = kartService;
            _CardTwoState = cardTwoState;
        }

        // [Authorize]
        [HttpGet]
        public IActionResult GetAllCards()
        {
            var cards = _kartService.GetAllCards();
            return Ok(cards);
        }

        // [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetCard(int id)
        {
            var card = _kartService.GetCardById(id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }


        // [Authorize]
        [HttpPost]
        public IActionResult AddCard([FromBody] CardEntity card)
        {
            // card.GirisTarihi = DateTime.UtcNow;
            card.TwoStageEntities = new List<CardTwoStageEntity> {};
            _kartService.AddCard(card);
            return Ok(card);
        }

        // [Authorize]
        [HttpPost("TwoStageData/{id}")] // İki aşamalı veri ekleme işlemi
        public IActionResult AddTwoStageData( int id,[FromBody] CardTwoStageEntity twoState)
        {
            try
            {
                _kartService.AddTwoStageData(id, twoState);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("TwoStageData/{id}")] // İki aşamalı veri ekleme işlemi
        public IActionResult getTwoStageData( int id)
        {
            try
            {
                var bla = _CardTwoState.GetTwoStageEntitiesForCard(id);
                Console.WriteLine(bla);
                return Ok(bla);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("TwoStageData")] // İki aşamalı veri ekleme işlemi
        public IActionResult updateTwoStageData( [FromBody] CardTwoStageEntity cardTwoStageEntity)
        {
            try
            {
                _CardTwoState.UpdateTwoStageData(cardTwoStageEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
        // [Authorize]
        [HttpPut]
        public IActionResult UpdateCard([FromBody] CardEntity card)
        {
            _kartService.UpdateCard(card);
            return Ok();
        }

        // [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            _kartService.DeleteCard(id);
            return Ok();
        }
    }
}
