﻿using Maxim1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Maxim1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
