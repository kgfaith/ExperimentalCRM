using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public int PictureSourceId { get; set; }
        public PictureSource PictureSource { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
