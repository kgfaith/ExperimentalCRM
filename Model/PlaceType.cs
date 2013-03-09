using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;


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
