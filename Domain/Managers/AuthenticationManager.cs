﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories;

namespace ExperimentalCMS.Domain.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private IUnitOfWork _uOW;

        public AuthenticationManager()
        {
        }

        public AuthenticationManager(IUnitOfWork uow)
        {
            _uOW = uow;
        }

        public bool IsValidBackEndAdminUser(string username, string password, out Admin admin)
        {
            admin = _uOW.AdminRepo.Get(u => u.UserName == username).SingleOrDefault();
            if (admin != null && BCryptHelper.CheckPassword(password, admin.PasswordHash))
            {
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _uOW.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
