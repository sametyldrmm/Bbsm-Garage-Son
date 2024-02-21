using Microsoft.AspNetCore.Mvc;
using Bbsm_Garage_Son.Entity;
using Bbsm_Garage_Son.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Bbsm_Garage_Son.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEntityController : ControllerBase
    {
        private readonly UserService _UserService;

        public UserEntityController(UserService UserService)
        {
            _UserService = UserService;
        }

        // [Authorize]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _UserService.GetAllUsers();
            return Ok(users);
        }

        // [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _UserService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // [Authorize]
        [HttpPost]
        public IActionResult AddUser([FromBody] UserEntity user)
        {
            // user.GirisTarihi = DateTime.UtcNow;
            // user.TwoStageEntities = new List<CardTwoStageEntity> {};
            _UserService.AddUser(user);
            return Ok(user);
        }

        // [HttpPost("addTwoStageData/{id}")] // İki aşamalı veri ekleme işlemi
        // public IActionResult AddTwoStageData( int id,[FromBody] CardTwoStageEntity twoState)
        // {
        //     try
        //     {
        //         _UserService.AddTwoStageData(id, twoState);
        //         return Ok();
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }
    
        // [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserEntity user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _UserService.UpdateUser(user);
            return NoContent();
        }

        // [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _UserService.DeleteUser(id);
            return Ok();
        }
    }
}
