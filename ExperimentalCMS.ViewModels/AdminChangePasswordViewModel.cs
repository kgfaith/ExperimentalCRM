using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.ViewModels
{
    public class AdminChangePasswordViewModel
    {
        public int AdminId { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }

        public void TransformFromAdminObject(Admin admin)
        {
            AdminId = admin.AdminId;
            UserName = admin.UserName;
            FullName = admin.FirstName + " " + admin.LastName;
            Email = admin.Email;
        }


    }
}
