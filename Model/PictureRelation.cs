using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class PictureRelation
    {
        public int PictureId { get; set; }
        public int RelatedEntityTypesId { get; set; }
        public int RelatedEntityId { get; set; }
    }
}
