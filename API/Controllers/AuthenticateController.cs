using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
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
    public class AuthenticateController : ControllerBase
    {
        private UserService _userService;
        private DoctorService _doctorService;
        private IMapper _mapper { get; }
        private ILoggerManager _logger { get; }

        public AuthenticateController(UserService userService,DoctorService doctorService, IMapper mapper, ILoggerManager logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
            _doctorService = doctorService;
        }

        [AllowAnonymous]
        [HttpPost("Login2")]
        public IActionResult Post([FromBody]LoginModel loginuser)
        {
            _logger.LogInfo("before Email=" + loginuser.Email + " Password=" + loginuser.Password);
            IActionResult response = BadRequest();
            User user = _userService.Authenticate(loginuser);
            if (user != null)
            {
                _logger.LogInfo("After " + user.Id);
                if (user.Role.Id==1)
                {
                    if (_doctorService.IsNotDeleted(user.Id))
                    {
                        response = Ok(_userService.BuildToken(_mapper.Map<UserModel>(user)));
                    }
                    else
                        response = BadRequest("is deleted");
                }
                else
                {
                    response = Ok(_userService.BuildToken(_mapper.Map<UserModel>(user)));
                }

            }
            return response;
        }

        [AllowAnonymous]
        [HttpPost("SignUpDoctor")]
        public IActionResult Post([FromBody]DoctorModel doctorModel)
        {
            _userService.SignUpAsDoctor(doctorModel);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("SignUpPatient")]
        public IActionResult Post([FromBody]PatientModel patientModel)
        {
            _userService.SignUpAsPatient(patientModel);
            return Ok();
        }

        [Authorize]
        [HttpPost("FCMToken")]
        public IActionResult Post([FromBody] Token token)
        {
            _userService.AddToken(token);
            return Ok();
        }

    }
}