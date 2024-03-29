﻿using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.SEC_User.Models;
using ProgrammingCode.DAL;
using System.Data;

namespace ProgrammingCode.Areas.Login.Controllers
{
    [Area("Login")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string? Email,string? Password)
        {
            string error = null;
            if (Email == null)
            {
                error += "User Name is required";
            }
            if (Password == null)
            {
                error += "<br/>Password is required";
            }

            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("Index");
            }
            else
            {
                DataTable dt = DBConfig.dbUser.SelectByUserNamePassword(Email,Password);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("DisplayName", dr["DisplayName"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("Index");
                }
                if (HttpContext.Session.GetString("Email") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return RedirectToAction("Index","Login" );
                }
            }
            @TempData["Message"] = HttpContext.Session.GetString("DisplayName");
            return RedirectToAction("Index", "Dashboard", new { Area = "Dashboard" });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
