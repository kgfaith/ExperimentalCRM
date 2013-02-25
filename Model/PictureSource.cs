using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExperimentalCMS.Model
{
    public class PictureSource
    {
        public int PictureSourceId { get; set; }

        [MaxLength(50)]
        public string SourceName { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
