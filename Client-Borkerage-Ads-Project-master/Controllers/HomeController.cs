﻿using Microsoft.AspNetCore.Mvc;

namespace Lab04.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Index);
        }

        public IActionResult Error()

        {

            return View(); // Do you need to modify this line? Use your judgement based on the app you developed so far 

        }
    }
}