using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EGramWebV2BLayer.Entities;
using EGramWebV2BLayer.Entities.Models.PanelModels;
using Microsoft.AspNetCore.Mvc;

namespace EGramWebV2.Controllers
{
    public class TestUserController : Controller
    {
        private readonly EGramWebDBContext _db = null;
        public IActionResult Index()
        {
            List<UserMst> userList = new List<UserMst>();
            userList = _db.UserMst.ToList();
            return View(userList);
        }
    }
}