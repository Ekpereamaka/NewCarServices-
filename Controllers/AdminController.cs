using Car_Hire_Services__CHS_.Database;
using Car_Hire_Services__CHS_.Enums;
using Car_Hire_Services__CHS_.IHelper;
using Car_Hire_Services__CHS_.Models;
using Car_Hire_Services__CHS_.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Hire_Services__CHS_.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IUserHelper _userHelper;
        private dynamic mycars;
        private object IuserHelper;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserHelper userHelper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _userHelper = userHelper;
        }
        public IActionResult Index()
        {
            var model = _context.Payment.Where(x => x.Id != 0).Include(x=> x.Cars).ToList();
            var data = model.Select(x => new CarViewModel
            {
                BankName = "First Bank",
                Product = x.Cars?.Name,
                Deleted = x.Deleted,
                Brand = x.Cars?.Brand,
                Amount = x.Amount,
                CustomerId = x.CustomerId,
                Active = x.Active,
                UserId = x.UserId,
                CarId = x.CarId,
                
            }).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddCustomerInfo()
        {
            var nation = _context.Nationality.ToList();
            ViewBag.Nationality = nation;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomerInfo(CustomerViewModel customers)
        {
            try
            {
                var nation = _context.Nationality.ToList();
                ViewBag.Nationality = nation;
                var checkEmail = _userManager.Users.Where(x => x.Email == customers.Email).FirstOrDefault();
                if (checkEmail != null)
                {
                    customers.ResponseOccured = true;
                    customers.ResponseMessage = "Email Already Exist";
                    return View(customers);
                }
                if (customers.StateId > 0 && customers.Email != null && customers.CustomerName != null)
                {
                    var customer = new Customer()
                    {
                        Address = customers.Address,
                        Email = customers.Email,
                        Phone = customers.Phone,
                        StateId = customers.StateId,
                        Description = customers.Description,
                        GuarantorsName = customers.GuarantorsName,
                        GuarantorsAddress = customers.GuarantorsAddress,
                        Deleted = customers.Deleted,
                        Active = true,
                        Name = customers.CustomerName,

                    };
                    _context.Customer.Add(customer);
                    _context.SaveChanges();
                    ModelState.Clear();
                    var model = new CustomerViewModel()
                    {
                        ResponseMessage = "Customer Registration is Successful",
                    };
                    return View(model);
                }
                customers.ResponseOccured = true;
                customers.ResponseMessage = "Customer Registration Failed";
                return View(customers);
            }
            catch (Exception)
            {

                throw;
            }



        }
        public IActionResult GetState(int stateId)
        {
            if (stateId != 0)
            {
                var states = _context.State.Where(x => x.NationalityId == stateId).ToList();
                return Json(new { isError = false, data = states });
            }
            return Json(new { isError = true, msg = "" });


        }
        [HttpGet]
        public IActionResult AddCarsByAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCarsByAdmin(CarViewModel carViewModel)
        {
            try
            {
                if (carViewModel != null)
                {
                    var image = _userHelper.UploadedFile(carViewModel.Image);
                    var carmodel = new mycar()
                    {
                        YearOfManifacture = carViewModel.YearOfManifacture,
                        Description = carViewModel.Description,
                        Type = carViewModel.Type,
                        Color = carViewModel.Color,
                        Brand = carViewModel.Brand,
                        Price = carViewModel.Price,
                        Image = image,
                        Id = carViewModel.Id,
                        Name = carViewModel.Brand,
                        Deleted = false,
                        Active = true,

                    };


                    _context.Cars.Add(carmodel);
                    _context.SaveChanges();
                    ModelState.Clear();
                    var model = new CarViewModel()
                    {
                        ResponseMessage = "upload is Successful",
                    };
                    return View(model);
                    carViewModel.ResponseOccured = true;
                    carViewModel.ResponseMessage = " Car upload Failed";

                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult CarsForRent()
        {
            var customers = _userHelper.GetCustomerDropDown();
            ViewBag.Customers = customers;
            var cars = _userHelper.GetCarDropDown();
            ViewBag.Cars = cars;
            var enums = ((ServiceType[])Enum.GetValues(typeof(ServiceType)))
                .Select(c => new DropdownEnumModel() { Id = (int)c, Name = c.ToString() }).ToList();
            ViewBag.ServicesType = enums;
            return View();
        }
        [HttpPost]
        public IActionResult Service(CustomerViewModel customers)
        {
            try
            {
                if (customers != null)
                {
                    //var carServices = new CarServices()
                    //{

                    //    CarId = customers.carId,
                    //    ServiceType = customers.ServiceType,
                    //    CustomerId = customers.Id,
                    //    Active = true,
                    //    Deleted = false,                 
                    //};
                    //if (customer != null)
                    //{
                    //    _context.Customers.Add(customer);
                    //    _context.SaveChanges();
                    //    return View(customers);
                    //}
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPrice(int? id)
        {
            if (id > 0)
            {
                var car = _context.Cars.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
                if (car != null)
                {
                    return Json(new { isError = false, data = car.Price });
                }
            }
            return Json(new { isError = true, data = 0 });
        }
        [HttpGet]
        public IActionResult AdminBankDetails(CarViewModel car)
        {
            if (car.CustomerId > 0 && car.Cars != null )
            {
                var customer = _context.Customer.Where(x => x.Id == car.CustomerId && !x.Deleted).FirstOrDefault();
                var myProduct = _context.Cars.Where(x => x.Id == Convert.ToInt32(car.Cars) && !x.Deleted).FirstOrDefault();
                var enums = Enum.GetName(typeof(ServiceType), car.ServiceTypeId);

                if (customer != null && myProduct != null)
                {
                    var product = new CarViewModel()
                    {
                        CustomerId = customer.Id,
                        CustomerName = customer.Name,
                        Price = myProduct.Price,
                        Color = myProduct.Color,
                        Brand = myProduct.Brand,
                        ServiceTypeId = car.ServiceTypeId
                    };
                    return View(product);
                }
            }
            return RedirectToAction ("CarsForRent");
        }
         [HttpPost]
        public IActionResult AdminCarPayment(CarViewModel paymentData)
        {
            try
            {
                if (paymentData.CustomerId != 0)
                {
                    var userName = User.Identity.Name;
                    var user = _userManager.Users.Where(x => x.Email == userName).FirstOrDefault();
                    var car = _context.Cars.Where(x => x.Name == paymentData.Name).FirstOrDefault();
                   
                    var carmodel = new Payment()
                    {
                        Amount = paymentData.Price,
                        CarServicesId = paymentData.ServiceTypeId.ToString(),
                        CustomerId = paymentData.CustomerId,
                        CarId = car.Id,
                        UserId = user.Id,
                        Name = car.Name,
                        Deleted = false,
                        Active = true,
                        ReferenceNo = paymentData.ReferenceNo,
                    }; 

                    _context.Payment.Add(carmodel);
                    _context.SaveChanges();
                    return Json(new { isError = false, msg = "Success" });
                }
                return Json( new {isError = true, msg = "Failed"});
            }
            catch (Exception ex)
            {

                throw  ex;
            }
        }

        //[HttpPost]
        //public IActionResult Payment(CarViewModel car)
        //{
        //    try
        //    {
        //        if (car != null)
        //        {
        //            var customer = new Car()
        //            {
        //                Name = Car.Name,
        //                Address = Car.Address,
        //                Phone = Car.Phone,
        //                nextofkin = Car.nextofkin,
        //            };
        //            if (customer != null)
        //            {
        //                _context.Cars.Add(customer);
        //                _context.SaveChanges();
        //                return View(customer);
        //            }
        //        }
        //        return View();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        


    }




}