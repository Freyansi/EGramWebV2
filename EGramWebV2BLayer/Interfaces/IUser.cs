using EGramWebV2BLayer.Entities.Models.ClientModels;
using EGramWebV2BLayer.Entities.Models.PanelModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGramWebV2BLayer.Interfaces
{
    public interface IUser
    {
        List<UserMst> GetUserList();
        UserMst GetUser(int id);
        List<SelectListItem> GetUserTypeMst();
        BaseResponseModel SaveUserMst(UserMst model);
        BaseResponseModel Delete(int id);

    }
}
