using Car_Hire_Services__CHS_.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Models
{
    public class mycar : BaseModel
    {
        public string YearOfManifacture { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }

        public string Price { get; set; }
        public string Description { get; set; }
        /*public string Product { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }*/

    }
}
