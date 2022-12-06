using Car_Hire_Services__CHS_.Models;
using Car_Hire_Services__CHS_.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.IHelper
{
    public interface IUserHelper
    {
        Task<ApplicationUser> FindUserByEmailAsync(string email);
        Task<ApplicationUser> FindUserByNameAsync(string username);
        Task<ApplicationUser> FindUserByIdAsync(string id);
        ApplicationUser FindUserByEmail(string email);
        ApplicationUser FindUserById(string firstname);
        ApplicationUser FindUserByUsername(string email);
        Task<ApplicationUser> CreateUserAsync(ApplicationUserViewModel model);
        string UploadedFile(IFormFile image);
        List<Customer> GetCustomerDropDown();
        List<mycar> GetCarDropDown();
        List<CarViewModel> GetCars();
    }
}
