using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EGramWebV2.Area.Panel.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserView()
        {
            return View();
        }
    }
}