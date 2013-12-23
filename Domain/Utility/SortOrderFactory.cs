using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Utility
{
    public static class PlaceSortOrderFactory
    {
        public static IOrderedQueryable<Place> GetSortOrder(IQueryable<Place> places, string sortOrder, bool isDescending)
        {
            if(isDescending)
            {
                switch (sortOrder)
                {
                    case Constants.SortOrders.PlaceName:
                        return places.OrderByDescending(place => place.PlaceName);
                    case Constants.SortOrders.Ranking:
                        return places.OrderByDescending(place => place.InternalRanking);
                }   
            }

            switch (sortOrder)
            {
                case Constants.SortOrders.PlaceName:
                    return places.OrderBy(place => place.PlaceName);
                case Constants.SortOrders.Ranking:
                    return places.OrderBy(place => place.InternalRanking);
            }
            return null;
        }
    }
}
