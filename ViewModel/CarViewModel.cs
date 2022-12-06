using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.ViewModel
{
    public class CarViewModel
    {
        [Key]
        public int Id { get; set; }
        public int ServiceTypeId { get; set; }
        public string Description { get; set; }
        public string Pictures { get; set; }
        public string YearOfManifacture { get; set; }
        public string Type { get; set; }
        public string ServicesType { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Cars { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public IFormFile Image { get; set; }
        public string Price { get; set; }
        public string Name{ get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Nextofkin { get; set; }
        public string BankName { get; set; }
        public  string AccountNumber { get; set; }
        public string Product { get; set; }
        public string ReferenceNo { get; set; }
        public string ResponseMessage { get; set; }
        public bool ResponseOccured { get; set; }
        public string Amount { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }
        public int CarId { get; set; }





    }
    
}
