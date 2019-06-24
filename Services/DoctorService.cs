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
    public class DoctorService
    {
        private readonly IDoctorReposatory _doctorReposatory;
        private readonly IUserReposatory _userReposatory;
        private readonly ICommentReposatory _commentReposatory;
        private readonly ITransactionReposatory _transactionReposatory;
        private readonly ISpecializationReposatory _specializationReposatory;
        private readonly IAddressReposatory _addressReposatory;
        private readonly IPhoneReposatory _phoneReposatory;
        private IMapper _mapper;
        public DoctorService(
            IUserReposatory userReposatory,
            ITransactionReposatory transactionReposatory,
            IDoctorReposatory doctorReposatory,
            ICommentReposatory commentReposatory, 
            ISpecializationReposatory specializationReposatory,
            IPhoneReposatory phoneReposatory,
            IAddressReposatory addressReposatory,
            IMapper mapper)
        {
            _addressReposatory = addressReposatory;
            _phoneReposatory = phoneReposatory;
            _doctorReposatory = doctorReposatory;
            _commentReposatory = commentReposatory;
            _userReposatory = userReposatory;
            _transactionReposatory = transactionReposatory;
            _specializationReposatory = specializationReposatory;
            _mapper = mapper;
        }
           
        public bool IsNotDeleted(int id)
        {
            return _userReposatory.Query().Where(a => a.Id == id).FirstOrDefault().Deleted == false;
        }
        public Transaction Response(int id, bool status)
        {
            Transaction transaction=_transactionReposatory.Query().Where(a => a.Id == id).FirstOrDefault();
            transaction.Accepted = status;
            _transactionReposatory.Update(transaction);
            return transaction;
        }

        public void EditDoctor(DoctorCardModel model)
        {
            Doctor doctor = _doctorReposatory.Query().Where(a => a.User_Id == model.User.Id)
               .Include(a => a.Specialization)
               .Include(a => a.User)
               .ThenInclude(a => a.Addresses)
               .Include(a => a.User)
               .ThenInclude(a => a.Phones).FirstOrDefault();
            Specialization specialization=_specializationReposatory.Query().Where(a => a.Spc_Name == model.Spc_Name).FirstOrDefault();
      
            doctor.Bio = model.Bio;
            doctor.Degree = model.Degree;
            doctor.Experience = model.Experience;
            doctor.Salary = model.Salary;
            doctor.Spec_Id = specialization.Id;

            _doctorReposatory.Update(doctor);

            doctor.User.Image = model.User.Image;
            doctor.User.Age = model.Age;
            doctor.User.Email = model.User.Email;
            doctor.User.Fname = model.User.Fname;
            doctor.User.Gender = model.User.Gender;
            doctor.User.Lname=model.User.Lname;

            _userReposatory.Update(doctor.User);

            foreach (Address item in doctor.User.Addresses.ToList<Address>())
            {
                _addressReposatory.Delete(item);
            }

            foreach (AddressModel item in model.Addresses.ToList<AddressModel>())
            {
                _addressReposatory.Add(new Address
                {
                    AddressType = item.AddressType,
                    City = item.City,
                    Region = item.Region,
                    street = item.street,
                    Usr_Id = doctor.User_Id
                });
            }

            foreach (Phone item in doctor.User.Phones.ToList<Phone>())
            {
                _phoneReposatory.Delete(item);
            }

            foreach (PhoneModel item in model.Phones.ToList<PhoneModel>())
            {
                _phoneReposatory.Add(new Phone()
                {
                    Number = item.Number,
                    Usr_Id = doctor.User_Id
                });
            }

        }

        public IEnumerable<DoctorCardModel> DoctorsCard(int id)
        {
           IEnumerable<Doctor> doctors= _doctorReposatory.Query().Where(u => u.User.Deleted == false && u.Verified&&u.Status&&u.User_Id!=id)
                .Include(a=>a.Certificates)
                .Include(a=>a.Specialization)
                .Include(a=>a.User)
                .ThenInclude(a=>a.Addresses)
                .Include(a => a.User)
                .ThenInclude(a => a.Phones);

            List<DoctorCardModel> doctorModels = (from a in doctors
                                                  select (new DoctorCardModel
                                                  {
                                                      Age = a.User.Age,
                                                      Bio = a.Bio,
                                                      Degree = a.Degree,
                                                      Salary = a.Salary,
                                                      Status = a.Status,
                                                      Experience = a.Experience,
                                                      Certificates = MapCertificationModels(a.Certificates),
                                                      Spc_Name = a.Specialization.Spc_Name,
                                                      User = _mapper.Map<UserProfileModel>(a.User),
                                                      Addresses = MapAddressModels(a.User.Addresses),
                                                      Phones = MapPhoneModels(a.User.Phones),
                                                      Reviews = GetReviews(a.User_Id)
                                                  })).ToList<DoctorCardModel>();
            return doctorModels;
        }

        public ICollection<ReviewsModel> GetReviews(int id)
        {
            return _commentReposatory.Query().Where(a => a.UserTo_Id == id).Select(a => new ReviewsModel
                    {
                        Comment = a.Desc,
                        Name = a.UserFrom.Fname + " " + a.UserFrom.Lname,
                        Rate = a.Rate,
                        User_From = a.UserFrom_Id
                    }).ToList<ReviewsModel>();
        }

        public List<AddressModel> MapAddressModels(ICollection<Address> addresses)
        {
            List<AddressModel> addressModels = new List<AddressModel>();
            foreach (Address item in addresses)
            {
                addressModels.Add(_mapper.Map<AddressModel>(item));
            }
            return addressModels;
        }

        public List<CertificationModel> MapCertificationModels(ICollection<Certificate> certificates)
        {
            List<CertificationModel> CertificationModels = new List<CertificationModel>();
            foreach (Certificate item in certificates)
            {
                CertificationModels.Add(_mapper.Map<CertificationModel>(item));
            }
            return CertificationModels;
        }

        public List<PhoneModel> MapPhoneModels(ICollection<Phone> phones)
        {
            List<PhoneModel> phoneModels = new List<PhoneModel>();
            foreach (Phone item in phones)
            {
                phoneModels.Add(_mapper.Map<PhoneModel>(item));
            }
            return phoneModels;
        }

        public DoctorCardModel GetDoctor(int id)
        {
            Doctor doctor=_doctorReposatory.Query().Where(a=>a.User_Id==id)
                .Include(a => a.Certificates)
                .Include(a => a.Specialization)
                .Include(a => a.User)
                .ThenInclude(a => a.Addresses)
                .Include(a => a.User)
                .ThenInclude(a => a.Phones).FirstOrDefault();


            DoctorCardModel doctorModel = new DoctorCardModel
            {
                Age=doctor.User.Age,
                Bio = doctor.Bio,
                Degree = doctor.Degree,
                Salary = doctor.Salary,
                Status = doctor.Status,
                Experience = doctor.Experience,
                Certificates = MapCertificationModels(doctor.Certificates),
                Spc_Name = doctor.Specialization.Spc_Name,
                User = _mapper.Map<UserProfileModel>(doctor.User),
                Addresses = MapAddressModels(doctor.User.Addresses),
                Phones = MapPhoneModels(doctor.User.Phones),
                Reviews = GetReviews(doctor.User_Id)
            };
            return doctorModel;
        }

        public void ChangeStatus(int id,bool status)
        {
            if(_doctorReposatory.Exist(a=>a.User_Id==id))
            {
                Doctor doctor=_doctorReposatory.Query().Where(a => a.User_Id == id).FirstOrDefault();
                doctor.Status = status;
                _doctorReposatory.Update(doctor);
            }
        }

        public List<Doctor> GetDoctorsNotVerified()
        {
          return  _doctorReposatory.Query().Include(a=>a.User).Where(a => a.Verified == false&&a.User.Deleted == false).ToList<Doctor>();
        }

        public List<Doctor> GetDoctors()
        {
            return _doctorReposatory.Query().Include(a => a.User).Where(a=>a.User.Deleted==false).ToList<Doctor>();
        }

        public int GetDoctorsCount()
        {
            return _doctorReposatory.Query().Include(a=>a.User).Where(a=>a.Verified==true&&a.User.Deleted == false).Count();
        }

        public void BlockDoctor(int id)
        {
            User user=_doctorReposatory.Query().Include(a => a.User).Where(a => a.User_Id == id).FirstOrDefault().User;
            user.Deleted = true;
            _userReposatory.Update(user);
        }

        public void VerifyDoctor(int id)
        {
           Doctor doctor= _doctorReposatory.Query().Where(a => a.User_Id == id).FirstOrDefault();
            doctor.Verified = true;
            _doctorReposatory.Update(doctor);
        }

        public void UnBlockDoctor(int id)
        {
            User user = _doctorReposatory.Query().Include(a => a.User).Where(a => a.User_Id == id).FirstOrDefault().User;
            user.Deleted = false;
            _userReposatory.Update(user);
        }

        public int ReportCount()
        {
            return _userReposatory.Query().Include(a=>a.ReportsTo).Where(a => a.Role_Id == 1 && a.ReportsTo.Count > 0).Count();
        }

        public List<User> GetDoctorReports()
        {
            return _userReposatory.Query().Include(a=>a.ReportsTo).Where(a => a.Role_Id == 1 && a.ReportsTo.Count > 0).ToList();
        }

    }
}

