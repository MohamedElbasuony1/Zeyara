using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private ILoggerManager _logger;
        ISpecializationReposatory _specializationReposatory;

        public SpecializationController(ILoggerManager logger,ISpecializationReposatory specializationReposatory)
        {
            _logger = logger;
            _specializationReposatory = specializationReposatory;
        }

        [AllowAnonymous]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_specializationReposatory.GetAll().Select(a=>a.Spc_Name));
        }
    }
}