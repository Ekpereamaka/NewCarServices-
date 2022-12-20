﻿using Car_Hire_Services__CHS_.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Models
{
    public class CarServices : BaseModel
    {
        public ServiceType ServiceType { get; set; }

        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public virtual Cars Cars { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

    }

}

