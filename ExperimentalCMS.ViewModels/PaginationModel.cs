using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalCMS.ViewModels
{
    public class PaginationModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public string SortOrder { get; set; }
        public bool SortAscending { get; set; }

        public string LinkAction { get; set; }
        public string LinkController { get; set; }
    }
}
