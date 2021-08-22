using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models.ViewModels;
using System.Data;
using System.Security.Cryptography;
using System.Web.Security;
using Restaurant.Models;
using Restaurant.DataAccess;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        #region Add User
        public ActionResult InsertUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertUser(InsertUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("InsertUser");
                }

                if (model != null)
                {
                    var PasswordSalt = Guid.NewGuid().ToString("N");
                    var SaltedPassword = model.Phone + PasswordSalt;
                    var SaltedPasswordByBytes = System.Text.Encoding.UTF8.GetBytes(SaltedPassword);
                    var HashedPassword = Convert.ToBase64String(SHA512.Create().ComputeHash(SaltedPasswordByBytes));

                    User user = new User
                    {
                        ID = model.ID,
                        FirstName = model.FiresName,
                        LastName = model.LastName,
                        Phone = model.Phone,
                        Email = model.Email,
                        Password = HashedPassword,
                        PasswordSalt = PasswordSalt,
                        Username = model.Email
                    };
                    bool result;
                    result = Restaurant.DataAccess.UserService.UserInsert(user);
                    if (result)
                    {
                        if(User.IsInRole("Admin"))
                        return RedirectToAction("SelectAllUsers", "User");
                        return RedirectToAction("LoginUser", "User");
                    }
                        
                    else
                        return View("InsertUser");
                }
                return View("InsertUser");

            }
            catch (Exception)
            {
                throw new Exception("خطا در سیستم !");
            }
        }
        #endregion

        #region Select
        public static User SelectUserByID(int id = 0)
        {
            DataTable dataTable = Restaurant.DataAccess.UserService.UserSelect(id: id);
            return Models.User.Convert(dataTable)[0];
        }
        public static User SelectUserByUsername(string username)
        {
            DataTable dataTable = Restaurant.DataAccess.UserService.UserSelectByUsername(username);
            return Models.User.Convert(dataTable)[0];
        }

        //bayad vorodi haye dg ham ezafe konim
        public ActionResult SelectUser(int ID)
        {
            DataTable dataTable = Restaurant.DataAccess.UserService.UserSelect(id: ID);
            List<User> list = Models.User.Convert(dataTable);
            return View(list);

        }



        [Authorize(Roles = "Admin")]
        public ActionResult SelectAllUsers()
        {
            DataTable dataTable = Restaurant.DataAccess.UserService.UserSelectAll();
            List<User> list = Models.User.Convert(dataTable);
            return View(list);
        }
        #endregion

        #region Edit
        //public ActionResult EditUser(int id)
        //{
        //    User oldUser = SelectUserByID(id);
        //    return View(oldUser);
        //}
        //[HttpPost]
        //public ActionResult EditUser(EditUserViewModel model)
        //{
        //    User user = new User();
        //    user = model.ConvertToModel();
        //    if (Restaurant.DataAccess.UserService.UserEdit(user))
        //        return RedirectToAction("Index", "Home");
        //    return View("EditUser");
        //}

        public ActionResult EditUser(int id)
        {
            User oldUser = SelectUserByID(id);
            EditUserViewModel viewModel = new EditUserViewModel(oldUser);
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult EditUser(EditUserViewModel model)
        {
            User user = new User();
            user = model.ConvertToModel();
            if (Restaurant.DataAccess.UserService.UserEdit(user))
                return RedirectToAction("SelectAllUsers", "User");
            return View("EditUser");
        }

        //
        //
        //


        public ActionResult EditSelfUser()
        {
            User oldUser = SelectUserByUsername(User.Identity.Name);
            EditSelfUserViewModel viewModel = new EditSelfUserViewModel(oldUser);
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult EditSelfUser(EditSelfUserViewModel model)
        {
            User user = new User();
            user = model.ConvertToModel();
            if (Restaurant.DataAccess.UserService.UserSelfEdit(user))
                return RedirectToAction("Index", "Home");
            return View("EditSelfUser");
        }

        #endregion

        #region Delete
        public ActionResult DeleteUser(int id)
        {
            if (UserService.UserDelete(id))
                return RedirectToAction("SelectAllUsers", "User");
            else
                return View("DeleteUser");

        }
        #endregion

        #region User Login
        public ActionResult LoginUser()
        {
            return View();
        }






        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(LoginUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("LoginUser");
                }

                if (model != null)
                {
                    DataTable dataTable = UserService.UserSelectByUsername(model.Username);
                    Models.User user = Restaurant.Models.User.Convert(dataTable)[0];
                    var SaltedPassword = model.Password + user.PasswordSalt;
                    var SaltedPasswordByBytes = System.Text.Encoding.UTF8.GetBytes(SaltedPassword);
                    var HashedPassword = Convert.ToBase64String(SHA512.Create().ComputeHash(SaltedPasswordByBytes));


                    if (UserService.UserLogin(model.Username, HashedPassword) == 1)
                    {

                        //var ticket = new FormsAuthenticationTicket(0, model.Username, DateTime.Now, DateTime.Now.AddMinutes(1), true, string.Empty);
                        //var encryptedticket = FormsAuthentication.Encrypt(ticket);
                        //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedticket)
                        //{
                        //    Expires = ticket.Expiration
                        //};
                        //Response.Cookies.Add(cookie);


                        // var authentication = HttpContext.GetOwinContext().Authentication;

                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                        ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);

                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Email));
                        identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));


                        identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

                        if (user.Role == 2)
                        {

                            identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                        }

                        AuthenticationManager.SignIn(identity);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "نام کاربری یا رمز عبور اشتباه است";
                        // return View("LoginUser");
                    }
                }
                return View("LoginUser");
            }

            catch (Exception)
            {

                throw new Exception("خطا در سیستم !");

            }


        }


        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }



        #endregion

        #region User Logout

        public ActionResult LogoutUser()
        {
            AuthenticationManager.SignOut();
            //FormsAuthentication.SignOut();
            return RedirectToAction("LoginUser", "User");
        }

        #endregion
    }
}