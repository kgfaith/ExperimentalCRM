using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Contracts
{
    public interface IAuthenticationManager
    {
        bool IsValidBackEndAdminUser(string username, string password, out Admin admin);
    }
}
