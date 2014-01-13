using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalCMS.Domain.Utility
{
    internal static class PlaceTypeMapper
    {
        public static Enums.PlaceTypes Map(int placeTypeId)
        {
            switch (placeTypeId)
            {
                case 2:
                    return Enums.PlaceTypes.State;
                case 3:
                    return Enums.PlaceTypes.TownCity;
                default:
                    return Enums.PlaceTypes.TouristAttraction;
            }
        }
    }
}
