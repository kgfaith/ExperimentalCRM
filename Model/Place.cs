using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace ExperimentalCMS.Model
{
    public class Place
    {
        public int PlaceId { get; set; }

        [Display(Name = "Place Name")]
        [MaxLength(100, ErrorMessage = "{1} can not be more than {0} string length")]
        public string PlaceName { get; set; }

        [MaxLength(25001)]
        public string Description { get; set; }

        public int InternalRanking { get; set; }
        public int PlaceTypeId { get; set; }
        public virtual PlaceType PlaceType { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Place> RelatedPlaces { get; set; }

        [InverseProperty("SlideShowPlaces")]
        public virtual ICollection<Picture> SlideshowPictures { get; set; }

        [InverseProperty("GalleryPlaces")]
        public virtual ICollection<Picture> PictureGallery { get; set; }

        [Required]
        public float Latitude { get; set; }

        [Required]
        public float Longitude { get; set; }
    }
}
