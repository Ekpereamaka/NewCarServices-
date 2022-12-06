using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Models
{
   
    public class Customer :BaseModel
    {
        public static bool Customers { get; internal set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        public string Occupation { get; set; }
        public string Description { get; set; }
        public string GuarantorsName { get; set; }
        public string GuarantorsNumber { get; set; }
        public string GuarantorsAddress { get; set; }
     
    }
}
