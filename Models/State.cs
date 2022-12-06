using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Models
{
    public class State: BaseModel
    {
        public int NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public virtual Nationality Nationality { get; set; }
    }
}
