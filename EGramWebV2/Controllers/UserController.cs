using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EGramWebV2.Models;
using EGramWebV2BLayer.Entities.Models.PanelModels;
using EGramWebV2BLayer.Entities;
using EGramWebV2BLayer.Interfaces;
using EGramWebV2BLayer.Entities.Models.ClientModels;

namespace EGramWebV2.Controllers
{
    public class UserController : Controller
    {
        public const string Temp_Success = "Success";
        public const string Temp_Error = "Error";
        private readonly IUser _Userservice;

        public UserController(IUser user)
        {
            _Userservice = user;
        }
        public IActionResult Index()
        {
            List<UserMst> model = new List<UserMst>();
            model = _Userservice.GetUserList();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddEdit(int id)
        {
            UserMst userMst = new UserMst();
            if (id != 0)
            {
                userMst = _Userservice.GetUser(id);
            }
            userMst.LstUserType = _Userservice.GetUserTypeMst();
            return View(userMst);
        }
        [HttpPost]
        public IActionResult AddEdit(UserMst userMst)
        {
            if (ModelState.IsValid)
            {
                BaseResponseModel response = _Userservice.SaveUserMst(userMst);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
