using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExperimentalCMS.Model
{
    public class PlaceType
    {
        public int PlaceTypeId { get; set; }

        [MaxLength(100)]
        public string PlaceTypeName { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
