using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }

        public int EntityTypeId { get; set; }
    }
}
