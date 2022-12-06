using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Deactivated { get; set; }
        public bool Deleted { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
        public string Picture { get; set; }
        public bool IsAdmin { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }


    }
}
