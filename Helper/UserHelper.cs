using Car_Hire_Services__CHS_.Database;
using Car_Hire_Services__CHS_.IHelper;
using Car_Hire_Services__CHS_.Models;
using Car_Hire_Services__CHS_.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Helper
{
    public class UserHelper : IUserHelper
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserHelper(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            return await _userManager.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
        public async Task<ApplicationUser> FindUserByNameAsync(string username)
        {
            return await _userManager.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }
        public async Task<ApplicationUser> FindUserByIdAsync(string id)
        {
            return await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public ApplicationUser FindUserByEmail(string email)
        {
            return _userManager.Users.Where(x => x.Email == email).FirstOrDefault();
        }
        public ApplicationUser FindUserById(string firstname)
        {
            return _userManager.Users.Where(x => x.Id == firstname).FirstOrDefault();
        }
        public ApplicationUser FindUserByUsername(string email)
        {
            return _userManager.Users.Where(x => x.UserName == email).FirstOrDefault();
        }
        public async Task<ApplicationUser> CreateUserAsync(ApplicationUserViewModel model)
        {
            try
            {
                var application = new ApplicationUser()//instantiate
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    StateId = Convert.ToInt32(model.State),
                    IsAdmin = false,
                };
                if (application.Email != null && application.UserName != null && application.Password != null && application.ConfirmPassword != null)
                {
                    application.DateRegistered = DateTime.Now;
                    var result = await _userManager.CreateAsync(application, application.Password);
                    if (result.Succeeded)
                    {
                        return application;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<ApplicationUser> CreateAdminAsync(ApplicationUserViewModel model)
        {
            try
            {
                var application = new ApplicationUser()//instantiate
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    StateId = Convert.ToInt32(model.State),
                    IsAdmin = true,
                };
                if (application.Email != null && application.UserName != null && application.Password != null && application.ConfirmPassword != null)
                {
                    application.DateRegistered = DateTime.Now;
                    var result = await _userManager.CreateAsync(application, application.Password);
                    if (result.Succeeded)
                    {
                        return application;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }





        public string UploadedFile(IFormFile image)
        {
            string uniqueFileName = string.Empty;
            string base64ImageRepresentation = string.Empty;

            if (image != null)
            {
                //C: \Users\User\Pictures\Saved Pictures
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string pathString = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(pathString))
                {
                    Directory.CreateDirectory(pathString);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                byte[] imageArray = File.ReadAllBytes(filePath);
                base64ImageRepresentation = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(imageArray));

                return base64ImageRepresentation;

            }

            return null;

        }

        public List<Customer> GetCustomerDropDown()
        {
            var customers = new Customer()
            {
                Id = 0,
                Name = "-- Select --",
            };
            var myCustomers = _context.Customer.ToList();
            myCustomers.Insert(0, customers);
            return myCustomers;
        }

        public List<Cars> GetCarDropDown()
        {
            var cars = new Cars()
            {
                Id = 0,
                Name = "-- Select --",
            };
            var mycars = _context.Cars.ToList();
            mycars.Insert(0, cars);
            return mycars;
        }
        public List<CarViewModel> GetCars()
        {
            var allCars = new List<CarViewModel>();
            var mycar = _context.Cars.Where(x => x.Id != 0 && x.Name != null && x.Active && !x.Deleted).Select(x => new CarViewModel
            {
                Name = x.Name,
                Id = x.Id,
                Color = x.Color,
                Brand = x.Brand,
                YearOfManifacture = x.YearOfManifacture,
                Price = x.Price,
            }).ToList();
            if (mycar != null && mycar.Count > 0)
            {
                return mycar;
            }
            return allCars;
        }


        public async Task<ApplicationUser> CreateAdminAsync(ApplicationUserViewModel admin)
        {
            try
            {
                var application = new ApplicationUser()//instantiate
                {
                    Email = admin.Email,
                    UserName = admin.Email,
                    Password = admin.Password,
                    ConfirmPassword = admin.ConfirmPassword,
                    StateId = Convert.ToInt32(admin.State),
                };
                if (application.Email != null && application.UserName != null && application.Password != null && application.ConfirmPassword != null)
                {
                    application.DateRegistered = DateTime.Now;
                    var result = await _userManager.CreateAsync(application, application.Password);
                    if (result.Succeeded)
                    {
                        return application;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }






    }
}
