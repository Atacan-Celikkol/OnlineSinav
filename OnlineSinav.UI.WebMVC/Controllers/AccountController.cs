using OnlineSinav.BLL.Concrete;
using OnlineSinav.Extensions;
using OnlineSinav.Model;
using OnlineSinav.UI.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSinav.UI.WebMVC.Controllers
{
    public class AccountController : Controller
    {
        UserService _userService;
        UserDetailService _userDetailService;
        UserRoleService _userRoleService;

        public AccountController()
        {
            _userService = new UserService();
            _userDetailService = new UserDetailService();
            _userRoleService = new UserRoleService();
        }

        public ActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerModel)
        {
            Model.User user = new Model.User()
            {
                EMail = registerModel.Mail,
                Name = registerModel.Firstname,
                Surname = registerModel.Lastname,
                Password = registerModel.Password,
                IsActive = false,
                ActivationCode = Guid.NewGuid(),
                UserRoleID = _userRoleService.GetByRoleName("User").UserRoleID
                //UserRole = _userRoleService.GetByRoleName("User")
            };

            _userService.Add(user);

            UserDetail userDetail = new UserDetail()
            {
                Address = registerModel.Address,
                BirthDate = registerModel.BirthDate,
                District = registerModel.District,
                City = registerModel.City,
                IsActive = true,
                UserID = user.UserID
            };
            _userDetailService.Add(userDetail);

            bool result = MailHelper.SendMail(user.EMail, user.ActivationCode);

            if (!result)
            {
                return RedirectToAction("NotFound");
            }

            return View();
        }

        public ActionResult ActivateUser(Guid activationCode)
        {
            Model.User user = _userService.GetByActivationCode(activationCode);
            if (user != null)
            {
                user.IsActive = true;
                _userService.Update(user);
                return RedirectToAction("Login");
            }

            return RedirectToAction("NotFound");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel)
        {
            Model.User user = _userService.GetByMailAndPassword(loginModel.EMail, loginModel.Password);
            if (user != null)
            {
                Session["user"] = user;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Mail adresi veya şifre hatalı";
            return View();
        }

        public ActionResult Logout()
        {
            //Session["user"] = null;
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}