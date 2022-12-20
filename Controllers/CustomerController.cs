using Car_Hire_Services__CHS_.Database;
using Car_Hire_Services__CHS_.IHelper;
using Car_Hire_Services__CHS_.Models;
using Car_Hire_Services__CHS_.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IUserHelper _userHelper;
        private dynamic mycars;
        private object IuserHelper;

        public CustomerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserHelper userHelper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _userHelper = userHelper;
        }
        [HttpGet]
        public IActionResult CustomerDetail()
        {
            ViewBag.Nationality = _context.Nationality.ToList();;
            return View();
        }

      
        [HttpPost]
        public JsonResult CustomerDetail(string customers)
        {
            try
            {
               
                ViewBag.Nationality = _context.Nationality.ToList();
                if (customers != null)
                {
                    var customerViewModel = JsonConvert.DeserializeObject<CustomerViewModel>(customers);
                    if (customerViewModel != null)
                    {
                        if (customerViewModel.PassWord != customerViewModel.ConfirmPassWord)
                        {
                            return Json(new { isError = true, mgs = "Email already exist" });
                        }
                        var checkEmail = _userManager.Users.Where(x => x.Email == customerViewModel.Email).FirstOrDefault();
                        if (checkEmail != null)
                        {
                            return Json(new { isError = true, mgs = "Email already exist" });
                        }
                        var customer = new Customer()
                        {
                            Address = customerViewModel.Address,
                            Email = customerViewModel.Email,
                            Phone = customerViewModel.Phone,
                            StateId = customerViewModel.StateId,
                            Description = customerViewModel.Description,
                            GuarantorsName = customerViewModel.GuarantorsName,
                            GuarantorsAddress = customerViewModel.GuarantorsAddress,
                            Deleted = false,
                            Active = true,
                            Name = customerViewModel.CustomerName,

                        };
                        _context.Customer.Add(customer);
                        _context.SaveChanges();
                        ModelState.Clear();
                        return Json(new { isError = false, msg = "Successful" });
                    }
                    
                }
                return Json(new { isError = true, msg = "Error Occurred" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
