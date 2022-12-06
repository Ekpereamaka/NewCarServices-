using Car_Hire_Services__CHS_.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Models
{
    public class Payment:BaseModel
    {
        public string Amount { get; set; }
        public string CarServicesId   { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public virtual mycar Cars { get; set; }

        public string ReferenceNo { get; set; }
    }
}
