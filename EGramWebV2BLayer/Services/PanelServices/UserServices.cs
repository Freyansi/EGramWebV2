using EGramWebV2BLayer.Entities;
using EGramWebV2BLayer.Entities.Models.PanelModels;
using EGramWebV2BLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EGramWebV2BLayer.Services.PanelServices
{
    public class UserServices : IUser
    {
        private readonly EGramWebDBContext _db = null;
        public List<UserMst> GetUserList()
        {
            var list = _db.UserMst.ToList();
            return list;
        } 
    }
}
