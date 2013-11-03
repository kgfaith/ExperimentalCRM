using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperimentalCMS.Model
{
    public class Picture
    {
        public int PictureId { get; set; }

        [MaxLength(50)]
        public string FileName { get; set; }

        [MaxLength(200)]
        public string OwnerName { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; }

        public int PictureSourceId { get; set; }
        public virtual PictureSource PictureSource { get; set; }

        [InverseProperty("SlideshowPictures")]
        public virtual ICollection<Place> SlideShowPlaces { get; set; }

        [InverseProperty("PictureGallery")]
        public virtual ICollection<Place> GalleryPlaces { get; set; }
    }
}
