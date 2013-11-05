using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.ViewModels.Enums;

namespace ExperimentalCMS.ViewModels
{
    public class PhotoViewModel
    {
        public string PictureId { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name = "Flickr Url")]
        public string FlickrUrl { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(50)]
        [Display(Name = "Owner Name")]
        [Required]
        public string OwnerName { get; set; }

        [MaxLength(500)]
        [Display(Name = "Picture Title")]
        public string Title { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }

        public int SourceId { get; set; }

        
    }
}
