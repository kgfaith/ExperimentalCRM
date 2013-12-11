using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.ViewModels
{
    public class PlaceListViewModel
    {
        public int PlaceTypeId { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
        public int PageNumber { get; set; }

        public IEnumerable<Place> Places { get; set; }
        
    }
}
