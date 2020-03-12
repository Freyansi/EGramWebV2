using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EGramWebV2BLayer.Entities.Models.PanelModels
{

    public class UserTypeMst
    {
        [Key]
        public short UserTypeId { get; set; }

        public string UserTypeName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreateDate { get; set; }
    }

    public class UserMst
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        [Display(Name = "User Name")]
        [StringLength(50, ErrorMessage = "username value cannot exceed 50 characters. ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please select user type")]
        [Display(Name = "User Type")]
        public short UserTypeId { get; set; }
        [ForeignKey("UserTypeId")]
        public UserTypeMst UserTypeMst { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password")]
        //[RegularExpression(@"^.(?=.*\d)(?=.*[a-zA-Z])(?=.*[@#$%^&+=]).{7,14}$", ErrorMessage = "Password must contain at least one letter, one digit and one special character (@#$%^&+=) and must be at least 8 to 15 characters")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must contain at least one letter, one digit and one special character (@#$%^&+=) and must be at least 8 to 15 characters")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Please enter confirm password.")]
        //[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password does not match with password.")]
        [NotMapped]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email Id")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(70, ErrorMessage = "Email must be within 70 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter email")]
        public string EmailId { get; set; }

        //[Required(ErrorMessage = "Please select website")]
        //public short? WebsiteId { get; set; }
        //public string WebsiteName { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        public string LastPassword { get; set; }

        public string LastPassword1 { get; set; }

        public string LastPassword2 { get; set; }

        public int? PasswordAttempt { get; set; }

        public DateTime? UnlockDate { get; set; }

        [NotMapped]
        public List<SelectListItem> LstUserType { get; set; }

        [NotMapped]
        public IPagedList<UserMst> LstUserMst { get; set; }
    }

    public class LoginHistory
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserMst UserMst { get; set; }

        public bool Status { get; set; }
        public DateTime LoginDate { get; set; }
        public string IP { get; set; }
    }

}
