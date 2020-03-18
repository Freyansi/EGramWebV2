using EGramWebV2BLayer.Entities.Models.PanelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGramWebV2BLayer.Interfaces
{
    public interface IUser
    {
         List<UserMst> GetUserList();
    }
}
