using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalCMS.ViewModels
{
    public class ColumnHeadingModel
    {
        public string ColumnHeading { get; set; }
        public string ColumnId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PlaceTypeId { get; set; }
        public string SortOrder { get; set; }
        public bool SortAscending { get; set; }
    }
}
