namespace ExperimentalCMS.Model
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
