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

        [Display(Name = "User name")]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }


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
