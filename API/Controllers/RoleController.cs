using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get()
        {
            return Ok(_roleService.GetRoles());
        }

        [HttpGet("AddRole/{role}")]
        [AllowAnonymous]
        public ActionResult Get(string role)
        {
            _roleService.AddRole(role);
            return Ok();
        }

    }
}