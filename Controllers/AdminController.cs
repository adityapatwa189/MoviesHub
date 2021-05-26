using AspCoreAppWithTests.Models;
using AspCoreAppWithTests.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace AspCoreAppWithTests.Controllers
{
    public class AdminController : Controller
    {
        public IUserRepository _repository { get; set; }
        public AdminController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("token")==null)
                return View("Login");
            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        public IActionResult Login(LoginCredential credentials)
        {
            if (ModelState.IsValid)
            {
                var user=_repository.GetUser(credentials);
                if (user == null)
                {
                    ViewBag.UserNameReason = "User Not Found";
                    return View(credentials);
                }
                else
                {
                    if (user.UserName == credentials.UserName && user.Password == credentials.Password)
                    {
                        HttpContext.Session.SetString("token", "logged in");
                        HttpContext.Session.SetString("userName", credentials.UserName);
                        return RedirectToAction("Index", "Movies");
                    }
                    else
                    {
                        ViewBag.PasswordReason = "Wrong Password!";
                        return View(credentials);
                    }
                }
            }
            return View(credentials);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Admin");
        }

    }
}
