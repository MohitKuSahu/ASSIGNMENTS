using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.Models
{
    public class UserModel
    {
        public int UserID { get; set; } 
       public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string GuardianName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string BloodGroup { get; set; }
        public string WorkExperience { get; set; }
        public string Documents { get; set; }
        public string Institute10th { get; set; }
        public string Board10th { get; set; }
        public int Percentage10th { get; set; }
        public string Institute12th { get; set; }
        public string Board12th { get; set; }
        public int Percentage12th { get; set; }
        public string InstituteBTECH { get; set; }
        public int PercentageBTECH { get; set; }

        public string FileName { get; set; }

        public string Profile { get; set; }


    }
}
