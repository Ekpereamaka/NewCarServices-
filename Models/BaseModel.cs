using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public bool Deleted  { get; set; }
        public bool Active { get; set; }
    }
}
