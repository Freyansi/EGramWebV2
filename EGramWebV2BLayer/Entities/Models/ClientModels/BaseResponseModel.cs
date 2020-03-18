using System;
using System.Collections.Generic;
using System.Text;

namespace EGramWebV2BLayer.Entities.Models.ClientModels
{
    public class BaseResponseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public BaseResponseModel()
        {
            Message = "Something went wrong.";
        }
    }
}
