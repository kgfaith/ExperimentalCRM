using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExperimentalCMS.ViewModels;

namespace ExperimentalCMS.Web.FrontEnd.Mappers
{
    public class PlaceViewModelMapper
    {
        public FePlaceViewModel Map()
        {
            var model = new FePlaceViewModel
                {
                    PlaceId = 0,
                    PlaceName = "something",
                    Longitude = 12,
                    Latitude = 23
                };
            return model;
        }
    }
}