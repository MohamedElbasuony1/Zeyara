using AutoMapper;
using Contracts;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class UserService
    {
        private readonly IUserReposatory _userReposatory;
        private readonly IDoctorReposatory _doctorReposatory;
        private readonly IAddressReposatory _addressReposatory;
        private readonly ICardReposatory _cardReposatory;
        private readonly IPhoneReposatory _phoneReposatory;
        private readonly IUserTokenReposatory _userTokenReposatory;
        private readonly ICertificateReposatory _certificateReposatory;
        private readonly IReportReposatory _reportReposatory;
        private readonly ICommentReposatory _commentReposatory;
        private IMapper _mapper;
        private IConfiguration _config { get; }
        private PasswordHasherService _passwordHasher { get; }
        private DoctorService _doctorService;

        public UserService(IUserReposatory userReposatory,
            IAddressReposatory addressReposatory,
            ICardReposatory cardReposatory,
            IPhoneReposatory phoneReposatory,
            ICertificateReposatory certificateReposatory,
            IDoctorReposatory doctorReposatory,
            IConfiguration config,
            PasswordHasherService passwordHasher,
            IUserTokenReposatory userTokenReposatory,
            IReportReposatory reportReposatory,
            ICommentReposatory commentReposatory,
            DoctorService doctorService,
            IMapper mapper)
        {
            _doctorService = doctorService;
            _commentReposatory = commentReposatory;
            _reportReposatory = reportReposatory;
            _userTokenReposatory = userTokenReposatory;
            _userReposatory = userReposatory;
            _doctorReposatory = doctorReposatory;
            _addressReposatory = addressReposatory;
            _cardReposatory = cardReposatory;
            _phoneReposatory = phoneReposatory;
            _certificateReposatory = certificateReposatory;
            _config = config;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public List<DoctorCardModel> Search(int spectialization, int minPrice, int maxPrice, float rate, string city, int id)
        {
          int[] Ids =_addressReposatory.Query().Where(a => a.City == city).Select(a => a.Usr_Id).ToArray<int>();

            List<Doctor> doctors = _doctorReposatory.Query()
                .Where(u => 
                        u.User.Deleted == false
                        && u.Verified
                        && u.Status
                        && u.User_Id != id
                        && u.Spec_Id == spectialization
                        && u.Salary >= minPrice
                        && u.Salary <= maxPrice
                        && u.User.Rate >= rate
                        &&Ids.Contains(u.User_Id)
                    )
               .Include(a => a.Certificates)
               .Include(a => a.Specialization)
               .Include(a => a.User)
               .ThenInclude(a => a.Addresses)
               .Include(a => a.User)
               .ThenInclude(a => a.Phones).ToList<Doctor>();

            

            List<DoctorCardModel> doctorModels = (from a in doctors
                                                  select (new DoctorCardModel
                                                  {
                                                      Age = a.User.Age,
                                                      Bio = a.Bio,
                                                      Degree = a.Degree,
                                                      Salary = a.Salary,
                                                      Status = a.Status,
                                                      Experience = a.Experience,
                                                      Certificates = _doctorService.MapCertificationModels(a.Certificates),
                                                      Spc_Name = a.Specialization.Spc_Name,
                                                      User = _mapper.Map<UserProfileModel>(a.User),
                                                      Addresses = _doctorService.MapAddressModels(a.User.Addresses),
                                                      Phones = _doctorService.MapPhoneModels(a.User.Phones),
                                                      Reviews = _doctorService.GetReviews(a.User_Id)
                                                  })).ToList<DoctorCardModel>();
            return doctorModels;
        }


        public UserModel BuildToken(UserModel user)
        {
            var claims = new[] {
                        new Claim(ClaimTypes.PrimarySid,user.Id.ToString()),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Role)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddDays(7),
              signingCredentials: creds
              );

            user.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return user;
        }

        public User Authenticate(LoginModel loginuser)
        {
            User user = _userReposatory.Query().Include(a => a.Role).FirstOrDefault(a => a.Email == loginuser.Email && _passwordHasher.VerifyPassword(a.Password, loginuser.Password));
            return user;
        }

        public UserProfileModel GetUserProfile(int id)
        {
           return _mapper.Map<UserProfileModel>(_userReposatory.Query().Where(a => a.Id == id).FirstOrDefault());
        }

        public void SignUpAsDoctor(DoctorModel model)
        {
            User user = _userReposatory.Add(new User
            {
                Fname = model.Fname,
                Lname = model.Lname,
                Age = model.Age,
                Image = model.Image,
                Gender = model.Gender,
                Deleted = model.Deleted,
                Email = model.Email,
                Password =_passwordHasher.HashPassword(model.Password),
                Rate = model.Rate,
                Role_Id = model.Role_Id,
                Widget = model.Widget,

            });

            foreach (Address item in model.Addresses)
            {
                _addressReposatory.Add(new Address
                {
                    AddressType = item.AddressType,
                    City = item.City,
                    Region = item.Region,
                    street = item.street,
                    Usr_Id = user.Id
                });
            }

            foreach (Phone item in model.Phones)
            {
                _phoneReposatory.Add(new Phone()
                {
                    Number = item.Number,
                    Usr_Id = user.Id
                });
            }

            Card card = _cardReposatory.Add(new Card()
            {
                Card_Type = model.Card.Card_Type,
                Number = model.Card.Number
            });

            Doctor doctor = _doctorReposatory.Add(new Doctor()
            {
                ESSN = model.ESSN,
                Bio = model.Bio,
                Experience = model.Experience,
                Degree = model.Degree,
                Status = model.Status,
                Salary = model.Salary,
                Card_Id = card.Number,
                User_Id = user.Id,
                Verified = model.Verified,
                OfficialCard = model.OfficialCard,
                Spec_Id=model.Specializations
            });
           
        }

        public void SignUpAsPatient(PatientModel model)
        {
            User user = _userReposatory.Add(new User
            {
                Fname = model.Fname,
                Lname = model.Lname,
                Age = model.Age,
                Image = model.Image,
                Gender = model.Gender,
                Deleted = false,
                Email = model.Email,
                Password = _passwordHasher.HashPassword(model.Password),
                Rate = 0,
                Role_Id = 2,
                Widget = 0
            }) ;

            foreach (AddressModel item in model.Addresses)
            {
                _addressReposatory.Add(new Address
                {
                    AddressType = item.AddressType,
                    City = item.City,
                    Region = item.Region,
                    street = item.street,
                    Usr_Id = user.Id
                });
            }

            foreach (PhoneModel item in model.Phones)
            {
                _phoneReposatory.Add(new Phone()
                {
                    Number = item.Number,
                    Usr_Id = user.Id
                });
            }
        }

        public string[] GetTokens(int id)
        {
           return  _userTokenReposatory.Query().Where(a => a.Usr_Id == id).Select(a => a.TokenNumber).ToArray<string>();
        }

        public void AddToken(Token token)
        {
            if(!(_userTokenReposatory.Exist(a => a.TokenNumber == token.token && a.Usr_Id == token.userId)))
            {
                _userTokenReposatory.Add(new UserToken
                {
                    TokenNumber=token.token,
                    Usr_Id=token.userId
                });
            }
        }

        public Report Report(Report report)
        {
            return _reportReposatory.Add(report);
        }

        public object AddComment(Comment comment)
        {
            return _commentReposatory.Add(comment);
        }
    }
}

