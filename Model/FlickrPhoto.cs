using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalCMS.Model
{
    public class FlickrPhoto
    {
        public string PictureId { get; set; }

        public string OwnerName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool AvailablePublic { get; set; }

        public string SmallImageUrl { get; set; }
    }
}
