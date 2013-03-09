using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;
using System.Collections.Generic;

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
