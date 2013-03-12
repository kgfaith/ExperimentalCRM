using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.ViewModels
{
    public class AdminEditViewModel
    {
        public int AdminId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }

        public Admin TransformToAdmin()
        {
            Admin adminObj = new Admin();
            adminObj.FirstName = FirstName;
            adminObj.LastName = LastName;
            adminObj.Email = Email;
            return adminObj;
        }

        public void TransformFromAdmin(Admin adminObj)
        {
            AdminId = adminObj.AdminId;
            FirstName = adminObj.FirstName ;
            LastName = adminObj.LastName;
            Email = adminObj.Email;
        }
    }
}
