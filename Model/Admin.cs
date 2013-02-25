using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using DevOne.Security.Cryptography.BCrypt;

namespace ExperimentalCMS.Model
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(200)]
        public string PasswordHash { get; set; }

        public string Something { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? LastLoginTime { get; set; }

        public bool Activated { get; set; }
     
        [NotMapped]
        public string Password
        {
            set {
                string salt = BCryptHelper.GenerateSalt(8);
                PasswordHash = BCryptHelper.HashPassword(value, salt); 
            }
        }

        internal static string GenerateRandomString()
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < 6; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(25 * random.NextDouble() + 75)));
            }
            return builder.ToString();
        }

        public string ResetPassword()
        {
            var newPass = GenerateRandomString();
            Password = newPass;
            return newPass;
        }
    }
}
