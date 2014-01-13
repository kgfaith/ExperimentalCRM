using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExperimentalCMS.Model;
using ExperimentalCMS.ViewModels;

namespace ExperimentalCMS.Web.BackEnd.Mappers
{
    internal class PhotoChildModelMapper
    {
        internal PlaceChildsViewModel Map(Place place)
        {
            var model = new PlaceChildsViewModel
            {
                PlaceTypeEnum = place.PlaceTypeEnum,
                StateChilds = place.StateChilds,
                AttractionChilds = place.AttractionChilds,
                TownCityChilds = place.TownCityChilds
            };
            return model;
        }
    }
}