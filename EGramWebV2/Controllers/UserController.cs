using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EGramWebV2.Models;
using EGramWebV2BLayer.Entities.Models.PanelModels;
using EGramWebV2BLayer.Entities;
using EGramWebV2BLayer.Services.PanelServices;

namespace EGramWebV2.Controllers
{
    public class UserController : Controller
    {
       // private readonly EGramWebDBContext _db = null;
        private readonly UserServices _Userservice;
        //public EGramWebDBContext db;
        public UserController(UserServices user)
        {
            _Userservice = user;
        }
        public IActionResult Index()
        {
            List<UserMst> model = new List<UserMst>();
            model = _Userservice.GetUserList();
            return View(model);
        }       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
