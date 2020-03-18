using EGramWebV2BLayer.Entities;
using EGramWebV2BLayer.Entities.Models.ClientModels;
using EGramWebV2BLayer.Entities.Models.PanelModels;
using EGramWebV2BLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EGramWebV2BLayer.Services.PanelServices
{
    public class UserServices : IUser
    {
        private readonly EGramWebDBContext _db = null;
        private List<SelectListItem> listItems;
        public UserServices(EGramWebDBContext context)
        {
            _db = context;
        }
        public List<UserMst> GetUserList()
        {
            var list = _db.UserMst.ToList();
            return list;
        } 
        public UserMst GetUser(int id)
        {
            UserMst model = new UserMst();
            model = _db.UserMst.Where(c => c.UserId == id).FirstOrDefault();
            return model;
        }
        public List<SelectListItem> GetUserTypeMst()
        {
            listItems = new List<SelectListItem>();
            IQueryable<UserTypeMst> query = from r in _db.UserTypeMst
                                            where r.IsActive == true
                                            select r;
            try
            {
                if (query != null)
                {
                    listItems.AddRange(query.Select(Item => new SelectListItem
                    {
                        Text = Item.UserTypeName,
                        Value = Item.UserTypeId.ToString()
                    }));
                }
                return listItems;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BaseResponseModel SaveUserMst(UserMst model)
        {
            BaseResponseModel baseResponseModel = new BaseResponseModel();
            UserMst UserMst = new UserMst();

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var oldData = _db.UserMst.Where(c => c.UserId == model.UserId).FirstOrDefault();
                    UserMst data = oldData == null ? new UserMst() : oldData;

                    data.UserName = model.UserName;
                    data.UserTypeId = model.UserTypeId;
                    data.Password = model.Password;
                    data.EmailId = model.EmailId;
                    data.IsActive = true;

                    if (oldData == null)
                    {
                        data.CreatedDate = DateTime.Now;
                        _db.UserMst.Add(data);
                    }
                    else
                    {
                        data.UpdateDate = DateTime.Now;
                        _db.UserMst.Update(data);

                    }

                    int j = _db.SaveChanges();

                    if (j >= 1)
                    {
                        baseResponseModel.IsSuccess = true;                      
                    }
                    else
                    {
                        baseResponseModel.IsSuccess = true;
                    }

                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return baseResponseModel;
        }
    }
}
