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
    public class PatientController : ControllerBase
    {
        private PatientService _patientService;
        private NotificationService _notificationService;
        private UserService _userService;
        public PatientController(PatientService patientService,NotificationService notificationService,UserService userService)
        {
            _userService = userService;
            _patientService = patientService;
            _notificationService = notificationService;
        }

        [HttpGet("Profile")]
        [Authorize]
        public ActionResult<PatientModel> Get(int userID)
        {
            ActionResult response = BadRequest("invalid Id");
            PatientModel patient = _patientService.GetPatient(userID);
            if (patient != null)
            {
                response = Ok(patient);
            }
            return response;
        }

        [HttpPost("Book")]
        [Authorize]
        public ActionResult Post(Book book)
        {
            ActionResult response = BadRequest("invalid data");
            Transaction transaction = _patientService.Book(book);
            if (transaction!=null)
            {
                UserProfileModel userProfile=_userService.GetUserProfile(book.patientId);
                Data data = new Data
                {
                    Id = book.patientId,
                    Image = userProfile.Image,
                    Lat = book.location.lat,
                    Long = book.location.longt,
                    Name = userProfile.Fname + " " + userProfile.Lname,
                    Tans_Id = transaction.Id,
                    body= "waiting to approve your request",
                    title= "You have a request"
                };
                _notificationService.SendNotification(_userService.GetTokens(book.doctorId), data);
                _notificationService.AddNotification(new Notification
                {
                    Date = DateTime.Now,
                    Message = "waiting to approve your request",
                    Read = true,
                    Tans_Id = transaction.Id,
                    UserFrom_Id=book.patientId,
                    UserTo_Id=book.doctorId
                });
                response = Ok();
            }
            return response;
        }

        [HttpPost("Edit")]
        [Authorize]
        public ActionResult Post(PatientModel model)
        {
            _patientService.EditPatient(model);
            return Ok();
        }

    }
}