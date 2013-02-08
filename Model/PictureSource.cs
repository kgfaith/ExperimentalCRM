using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Model
{
    public class PictureSource
    {
        public int PictureSourceId { get; set; }

        [MaxLength(50)]
        public string SourceName { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
