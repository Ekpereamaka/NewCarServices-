using Car_Hire_Services__CHS_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.ViewModel
{
    public class ApplicationUserViewModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string State { get; set; }
        public bool Activated { get; set; }
        public string Deactivated { get; set; }
        public bool Deleted { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string City { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
        public string CarModel { get; set; }
        public string Price { get; set; }
        public string CarColor { get; set; }
        public string Location { get; set; }
        public string Mileage { get; set; }
        public string Picture { get; set; }
        public string Guarantor { get; set; }
        public string GuarantorID { get; set; }
        public string InternationalPassport { get; set; }

        public bool ErrorResponseOccured{ get; set; }
        public string ResponseMessage { get; set; }
    }
}
