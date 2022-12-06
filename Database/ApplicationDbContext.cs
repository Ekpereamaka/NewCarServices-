using Car_Hire_Services__CHS_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CarServices> CateCarHireServices { get; set; }
    
        public DbSet<mycar> Cars { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Customer> Customer { get; set; }
        //public DbSet<Product> Product { get; set; }
       



    }


}
