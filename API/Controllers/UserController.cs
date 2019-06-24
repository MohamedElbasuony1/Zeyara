using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Report")]
        [Authorize]
        public ActionResult Post(Report report)
        {
            if (_userService.Report(report) != null)
                return Ok();
            else
                return BadRequest("invalid data");
        }

        [HttpPost("Rate")]
        [Authorize]
        public ActionResult Post(Comment comment)
        {
            if (_userService.AddComment(comment) != null)
                return Ok();
            else
                return BadRequest("invalid data");
        }

        [HttpGet("Search")]
        [Authorize]
        public ActionResult<List<DoctorCardModel>> Get(int Spectialization, int minPrice, int maxPrice, float Rate, string City, int id)
        {
            return _userService.Search(Spectialization, minPrice, maxPrice, Rate, City, id);
        }

    }
}