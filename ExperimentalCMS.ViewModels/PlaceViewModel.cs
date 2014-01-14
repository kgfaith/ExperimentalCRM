using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.ViewModels
{
    public class PlaceViewModel
    {
        public int? PlaceId { get; set; }

        [Display(Name = "Place Name")]
        [MaxLength(100, ErrorMessage = "{1} can not be more than {0} string length")]
        public string PlaceName { get; set; }

        [MaxLength(25001)]
        [AllowHtml]
        public string Description { get; set; }

        public int InternalRanking { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public int? PlaceTypeId { get; set; }
        public PlaceType PlaceType { get; set; }

        public int? ParentStateId { get; set; }
        public Place ParentState { get; set; }

        public int? ParentCityTownId { get; set; }
        public Place ParentCityTown { get; set; }

        public int? ParentAttractionId { get; set; }
        public Place ParentAttraction { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<Picture> SlideShowPictures { get; set; }
        //public ICollection<Place> RelatedPlaces { get; set; }

        public string RelatedArticleIds { get; set; }
        public string RelatedPlaceIds { get; set; }
        public string RelatedSlideShowPictureIds { get; set; }

        public Place TransformToPlaceObject()
        {
            Place placeObj = new Place();
            placeObj.PlaceId = PlaceId.HasValue ? PlaceId.Value : 0;
            placeObj.PlaceName = PlaceName;
            placeObj.Description = Description;
            placeObj.InternalRanking = InternalRanking;
            placeObj.PlaceTypeId = PlaceTypeId.Value;
            placeObj.ParentStateId = ParentStateId;
            placeObj.ParentTownCityId = ParentCityTownId;
            placeObj.ParentAttractionId = ParentAttractionId;
            placeObj.Latitude = Latitude;
            placeObj.Longitude = Longitude;
            return placeObj;
        }
    }
}
