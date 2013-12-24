using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Utility
{
    public static class PlaceSortOrderExpressionFactory
    {
        public static Expression<Func<Place, object>> GetSortOrderExpression(string sortOrder)
        {
            switch (sortOrder)
            {
                case Constants.SortOrders.PlaceName:
                    return p => p.PlaceName;
                case Constants.SortOrders.Ranking:
                    return p => p.InternalRanking;
            }
            return null;
        }
    }
}
