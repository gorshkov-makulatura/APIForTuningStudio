
using NEWAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoTuneAPI.Models
{
    public class ResponseUser
    {
        public ResponseUser(Users users)
        {
            if (users == null) return;
            ID = users.ID;
            GenderID = users.GenderID;
            SecondName = users.SecondName;
            FirstName = users.FirstName;
            LastName = users.LastName;
            BirthDate = (DateTime)users.BirthDate;
            PhoneNumber = users.PhoneNumber;
            Email = users.Email;
            RoleID = users.RoleID;
            Photo = users.Photo;
            Password = users.Password;
            IsActive = (bool)users.IsActive;
            RoleName = users.Roles.Name;
        }

        public int ID { get; set; }
        public int GenderID { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public byte[] Photo { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string RoleName { get; set; }

    }
}