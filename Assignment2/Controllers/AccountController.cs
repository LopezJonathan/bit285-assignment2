using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;
using Assignment2.ViewModels;

namespace Assignment2.Controllers
{
    public class AccountController : Controller
    {
        private VisitorLogContext db = new VisitorLogContext();
        
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (isUser(user.UserName))
            {
                Activity newActivity = new Activity();
                newActivity.ActivityDate = DateTime.Now;
                newActivity.ActivityName = user.UserName;
                newActivity.IpAddress = Request.UserHostAddress;
                db.Activities.Add(newActivity);
                db.SaveChanges();

                return View("./HomeController/Index", db.Activities);
            }

            else
            {
                ModelState.Clear();
                ModelState.AddModelError("ErrorMessage", "Your login attempt was not successful. Please try again.");

                return View("Login");
            }
        }

        //GET: New Account
        [HttpGet]
        public ActionResult NewAccount()
        {
            NewAccountViewModel NewUserAccount = new NewAccountViewModel();
            return View("NewAccount", NewUserAccount);
        }

        //POST: New Account
        [HttpPost]
        public ActionResult NewAccount(NewAccountViewModel nAccount, string create, string reset)
        {
            if (!string.IsNullOrEmpty(create))
            {
                if (!isUser(nAccount.FirstName))
                {
                    User newUser = new User();

                    newUser.FirstName = nAccount.FirstName;
                    newUser.LastName = nAccount.LastName;
                    newUser.Email = nAccount.Email;
                    newUser.EmailUpdates = nAccount.EmailUpdates;
                    newUser.ProgramID = nAccount.ProgramID;
                    Session["tempUser"] = newUser;

                    return View("Password");
                }

                else
                {
                    return View("NewAccount");
                }
            }

            else
            {
                ModelState.Clear();
                return View("NewAccount");
            }
        }

        //GET: Password
        [HttpGet]
        public ActionResult Password()
        {
            return View("Password");
        }

        //POST: Password
        [HttpPost]
        public ActionResult Password(PasswordGeneratorViewModel newPassword, string suggestion, string submit)
        {
            if (!string.IsNullOrEmpty(suggestion))
            {
                ViewBag.items = PasswordGen(newPassword);
                return PartialView("Password");
            }

            else if(!string.IsNullOrEmpty(submit) && ModelState.IsValid)
            {

            }

            return View();
        }

        private List<string> PasswordGen(PasswordGeneratorViewModel newPassword)
        {
            //Store user input from textboxes
            string lName = newPassword.LastName.Replace(" ", string.Empty);
            string bYear = newPassword.BirthYear.ToString().Replace(" ", string.Empty);
            string favColor = newPassword.FavoriteColor.Replace(" ", string.Empty);

            //Creating and storing the passwords
            string password1 = lName.Insert(lName.Length / 2, favColor);
            string password2 = string.Concat(favColor, bYear, lName.Remove(1));
            string password3 = bYear.Insert(bYear.Length / 2, favColor);
            string password4 = string.Concat(ReverseString(bYear), lName);
            string password5 = string.Concat(lName.Remove(1), favColor, favColor, favColor);

            //Put the created passwords into an array
            string[] passwords = new string[] { password1, password2, password3, password4, password5 };

            List<string> items = new List<string>
            {
                password1, password2, password3, password4, password5
            };

            return items;
        }

        //This method will take a string as parameter and reverse it
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private bool isUser(string user)
        {
            return db.Users.ToList().Any(m => m.Email == user);
        }

        /**
         * Store temporary user in Session during account creation
         */
        private User GetTempUser()
        {
            if (Session["tempUser"] == null)
            {
                Session["tempUser"] = new User();
            }
            return (User)Session["tempUser"];
        }

        private void FlushTempUser()
        {
            Session.Remove("tempUser");
        }
    }
}