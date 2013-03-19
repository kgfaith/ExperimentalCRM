using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalCMS.Domain.Utility
{
    public class Response<T> where T : class
    {
        public bool Success { get; set; }
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
