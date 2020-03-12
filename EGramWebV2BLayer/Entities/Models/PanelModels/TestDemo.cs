using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EGramWebV2BLayer.Entities.Models.PanelModels
{

    public class TestDemo
    {
        [Key]
        public short UserTypeId { get; set; }

        public string UserTypeName { get; set; }

        public bool IsActive { get; set; }

        //public DateTime? CreateDate { get; set; }
    }

}
