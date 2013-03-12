using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalCMS.Repositories
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();
    }
}
