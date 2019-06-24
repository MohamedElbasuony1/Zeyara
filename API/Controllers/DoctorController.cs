using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
    public class DoctorController : ControllerBase
    {
        private DoctorService _doctorService;
        private NotificationService _notificationService;
        private UserService _userService;
        private ILoggerManager _logger;

        public DoctorController(DoctorService doctorService,ILoggerManager logger,NotificationService notificationService, UserService userService)
        {
            _userService = userService;
            _doctorService = doctorService;
            _notificationService = notificationService;
            _logger = logger;
        }

        [HttpGet("DoctorsCard")]
        [Authorize]
        public ActionResult<IEnumerable<DoctorCardModel>> GetDoctorsCard(int id)
        {
            _logger.LogInfo("Enter");
            IEnumerable<DoctorCardModel> doctorCards =_doctorService.DoctorsCard(id);
            _logger.LogInfo("after");
             return Ok(doctorCards);
        }

        [HttpGet("Doctors")]
        [AllowAnonymous]
        public ActionResult<List<Doctor>> Get()
        {
           return Ok(_doctorService.GetDoctors());
        }

        [HttpGet("NonVerified")]
        [AllowAnonymous]
        public ActionResult<List<Doctor>> GetNonVerified()
        {
            return Ok(_doctorService.GetDoctorsNotVerified());
        }

        [HttpGet("Verify/{id}")]
        [AllowAnonymous]
        public ActionResult<List<Doctor>> GetVerify(int id)
        {
            _doctorService.VerifyDoctor(id);
            return Ok();
        }

        [HttpGet("Count")]
        [AllowAnonymous]
        public ActionResult GetCount()
        {
            return Ok(_doctorService.GetDoctorsCount());
        }

        [HttpGet("ReportCount")]
        [AllowAnonymous]
        public ActionResult GetReportCount()
        {
            return Ok(_doctorService.ReportCount());
        }

        [HttpGet("ReportedDoctors")]
        [AllowAnonymous]
        public ActionResult GetReportedDoctors()
        {
            return Ok(_doctorService.GetDoctorReports());
        }

        [HttpGet("Block/{id}")]
        [AllowAnonymous]
        public ActionResult GetBlock(int id)
        {
            _doctorService.BlockDoctor(id);
            return Ok();
        }

        [HttpGet("UnBlock/{id}")]
        [AllowAnonymous]
        public ActionResult GetUnBlock(int id)
        {
            _doctorService.UnBlockDoctor(id);
            return Ok();
        }

        [HttpGet("Profile")]
        [Authorize]
        public ActionResult<DoctorCardModel> GetProfile(int userID)
        {
            ActionResult respose = BadRequest("invalid Id");
             DoctorCardModel doctor=_doctorService.GetDoctor(userID);
            if (doctor!=null)
            {
                respose = Ok(doctor);
            }
            return doctor;
        }

        [HttpPost("Edit")]
        [Authorize]
        public ActionResult Post(DoctorCardModel model)
        {
            _doctorService.EditDoctor(model);
            return Ok();
        }

        [HttpGet("Status")]
        [Authorize]
        public ActionResult GetStatus(int userID,bool status)
        {
            _doctorService.ChangeStatus(userID, status);
            return Ok();
        }

        [HttpGet("Response")]
        [Authorize]
        public ActionResult GetRespose(int transaction,bool status)
        {
            ActionResult respose = BadRequest("invalid Id");
            Transaction Mytransaction=_doctorService.Response(transaction, status);
            if (Mytransaction!=null)
            {
                UserProfileModel userProfile = _userService.GetUserProfile(Mytransaction.Doctor_Id);
                Data data = new Data
                {
                    Id = Mytransaction.Doctor_Id,
                    Image = userProfile.Image,
                    Lat = "jjj",
                    Long = "jjg",
                    Name = userProfile.Fname + " " + userProfile.Lname,
                    Tans_Id = Mytransaction.Id
                };
                if ((bool)Mytransaction.Accepted)
                {
                    data.body = "Approved Your Request";
                    data.title = "You have new notification";
                    _notificationService.SendNotification(_userService.GetTokens(Mytransaction.Patient_Id), data);
                }
                else
                {
                    data.body = "Refused Your Request";
                    data.title = "You have new notification";
                    _notificationService.SendNotification(_userService.GetTokens(Mytransaction.Patient_Id), data);
                }
                _notificationService.AddNotification(new Notification
                {
                    Date = DateTime.Now,
                    Message = "waiting for approving your request",
                    Read = true,
                    Tans_Id = transaction,
                    UserFrom_Id = Mytransaction.Doctor_Id,
                    UserTo_Id = Mytransaction.Patient_Id
                });
                respose = Ok();
            }
            return respose;
        }

    }
}