using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace ExperimentalCMS.Model
{
    public class Place
    {
        public int PlaceId { get; set; }

        [Display(Name = "Place Name")]
        [MaxLength(100, ErrorMessage = "{1} can not be more than {0} string length")]
        public string PlaceName { get; set; }

        [MaxLength(2500)]
        public string Description { get; set; }

        public int PlaceTypeId { get; set; }
        public PlaceType PlaceType { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Picture> Pictures { get; set; }  
    }
}
