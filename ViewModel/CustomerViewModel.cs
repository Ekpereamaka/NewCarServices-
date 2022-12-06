using Car_Hire_Services__CHS_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.ViewModel
{
    public class CustomerViewModel
    {
        [Key]
        public int Int { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int StateId { get; set; }
        public string Occupation { get; set; }
        public string Description { get; set; }
        public string GuarantorsName { get; set; }
        public string GuarantorsNumber { get; set; }
        public string GuarantorsAddress { get; set; }
        public int CountryId { get; internal set; }
        public string City { get; internal set; }
        public string ResponseMessage { get; internal set; }
        public bool ResponseOccured { get; internal set; }
        public bool Deleted { get; internal set; }
    }
}
