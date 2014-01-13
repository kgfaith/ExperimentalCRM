using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.ViewModels
{
    public class PlaceChildsViewModel
    {
        public int PlaceId { get; set; }
        public int PlaceTypeId { get; set; }
        public Enums.PlaceTypes PlaceTypeEnum { get; set; }
        public virtual ICollection<Place> StateChilds { get; set; }
        public virtual ICollection<Place> AttractionChilds { get; set; }
        public virtual ICollection<Place> TownCityChilds { get; set; }
    }
}
