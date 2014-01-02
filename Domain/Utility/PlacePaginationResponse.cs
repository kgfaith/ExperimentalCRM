using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Utility
{
    public class PlacePaginationResponse : DomainResponse<IEnumerable<Place>>
    {
        public int TotalPages;
        public PlacePaginationResponse()
        {

        }
    }
}
