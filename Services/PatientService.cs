using AutoMapper;
using Contracts;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class PatientService
    {
        private readonly IUserReposatory _userReposatory;
        private readonly ITransactionReposatory _transactionReposatory;
        private readonly DoctorService _doctorService;
        private readonly IAddressReposatory _addressReposatory;
        private readonly IPhoneReposatory _phoneReposatory;
        private IMapper _mapper;
        public PatientService(IUserReposatory userReposatory,
            DoctorService doctorService,
            ITransactionReposatory transactionReposatory,
            IAddressReposatory addressReposatory,
            IPhoneReposatory phoneReposatory,
            IMapper mapper)
        {
            _phoneReposatory = phoneReposatory;
            _userReposatory = userReposatory;
            _transactionReposatory = transactionReposatory;
            _doctorService = doctorService;
            _addressReposatory = addressReposatory;
            _mapper = mapper;
        }

        public Transaction Book(Book book)
        {
            return _transactionReposatory.Add(new Transaction
            {
                Location = book.location.ToString(),
                Accepted = null,
                Completed = null,
                Date = DateTime.Now,
                Doctor_Id = book.doctorId,
                Patient_Id = book.patientId,
                QR_Code = "midomido"
            });
        }

        public PatientModel GetPatient(int Id)
        {
           User user= _userReposatory.Query().Where(a => a.Id == Id)
                .Include(a => a.Addresses)
                .Include(a => a.Phones)
                .Include(a => a.CommentsTo)
                .FirstOrDefault();

            if (user!=null)
            {
                return new PatientModel
                {
                    Id=user.Id,
                    Addresses = _doctorService.MapAddressModels(user.Addresses),
                    Age = user.Age,
                    Email = user.Email,
                    Gender = user.Gender,
                    Fname = user.Fname,
                    Image = user.Image,
                    Lname = user.Lname,
                    Password= user.Password,
                    Phones = _doctorService.MapPhoneModels(user.Phones),
                    Widget = user.Widget,
                    Reviews = _doctorService.GetReviews(Id)
                };
            }
            return null;
        }

        public void EditPatient(PatientModel model)
        {
            User user = _userReposatory.Query().Where(a => a.Id == model.Id)
                .Include(a => a.Addresses)
                .Include(a => a.Phones).FirstOrDefault();

            user.Image = model.Image;
            user.Age = model.Age;
            user.Email = model.Email;
            user.Fname = model.Fname;
            user.Gender = model.Gender;
            user.Lname = model.Lname;

            _userReposatory.Update(user);

            foreach (Address item in user.Addresses.ToList<Address>())
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
                    Usr_Id = user.Id
                });
            }

            foreach (Phone item in user.Phones.ToList<Phone>())
            {
                _phoneReposatory.Delete(item);
            }

            foreach (PhoneModel item in model.Phones.ToList<PhoneModel>())
            {
                _phoneReposatory.Add(new Phone()
                {
                    Number = item.Number,
                    Usr_Id = user.Id
                });
            }
        }

    }
}
