﻿using Microsoft.AspNetCore.Mvc;

namespace ProgrammingCode.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
