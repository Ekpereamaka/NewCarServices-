using Car_Hire_Services__CHS_.Database;
using Car_Hire_Services__CHS_.IHelper;
using Car_Hire_Services__CHS_.Models;
using Car_Hire_Services__CHS_.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserHelper _userHelper;

        public AccountController( ApplicationDbContext context, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IUserHelper userHelper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _userHelper = userHelper;
        }

        public  IActionResult Index()
        {
            return View();
        }
        
        
        [HttpGet]
        public IActionResult Register()// Action that doesn't require parameter
        {
            var nation =_context.Nationality.Where(x => x.Id !=0).ToList();
            ViewBag.Nationality = nation;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUserViewModel applicationUserViewModel)// Action that requires a parameter
        {
            var nation = _context.Nationality.Where(x => x.Id != 0).ToList();
            ViewBag.Nationality = nation;            
            try
            {
               
                if (ModelState != null)
                {
                    if (applicationUserViewModel.Password != applicationUserViewModel.ConfirmPassword)
                    {
                        applicationUserViewModel.ErrorResponseOccured = true;
                        applicationUserViewModel.ResponseMessage = "Password does not Match Please Check!.";
                        return View(applicationUserViewModel);
                    }

                    if (applicationUserViewModel.State == null)
                    {
                        applicationUserViewModel.ErrorResponseOccured = true;
                        applicationUserViewModel.ResponseMessage = " Please select state.";
                        return View(applicationUserViewModel);
                    }

                    //lambda is you to target a particular column in a table
                    var isEmail = _userManager.Users.Where(x => x.Email == applicationUserViewModel.Email).FirstOrDefault();
                    if (isEmail != null)
                    {
                        applicationUserViewModel.ErrorResponseOccured = true;
                        applicationUserViewModel.ResponseMessage = "Email already exist!.";
                        return View(applicationUserViewModel);
                    }
                   
                    var user = await _userHelper.CreateUserAsync(applicationUserViewModel);
                    if (user != null)
                    {
                        //applicationUserViewModel.ErrorResponseOccured = false;
                        //(TUser user, string password, bool isPersistent, bool lockoutOn
                        await _signInManager.PasswordSignInAsync(user, user.Password,  true, false);
                           
                        return RedirectToAction("Index", "Home");
                    }
                }
                applicationUserViewModel.ErrorResponseOccured = false;
                return View(applicationUserViewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var logginUser = _context.ApplicationUsers.Where(x => x.Email == model.Email && !x.Deleted).FirstOrDefault();
                if (logginUser !=null)
                {
                    var result = await _signInManager.PasswordSignInAsync(logginUser.UserName, logginUser.Password, true, true);
                    if (result.Succeeded)
                    {

                        model.ErrorResponseOccured = false;
                        return RedirectToAction("index", "home");
                    }
                    model.ErrorResponseOccured = true;
                    model.ResponseMessage = "Invalid Login Attempt";
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
                
            }
            return View(model);
        }
       
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        public IActionResult GetState(int countryId)
        {
            if (countryId != 0)
            {
                var states = _context.State.Where(x => x.NationalityId == countryId).ToList();
                return Json(new { isError = false, data = states });
            }
            return Json(new { isError = true, msg="" });


        }

    }
}
