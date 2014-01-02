using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExperimentalCMS.Domain.Utility;
using ExperimentalCMS.Model;
using ExperimentalCMS.ViewModels;
using ExperimentalCMS.Web.BackEnd.Domain;

namespace ExperimentalCMS.Web.BackEnd.Mappers
{
    internal static class PlaceListViewModelMapper
    {
        internal static PlaceListViewModel Map( UrlHelper urlHelper, PlacePaginationResponse response, int pageSize = 10, int pageNumber = 1, string sortOrder = "PlaceName", bool sortAscending = true, int PlaceTypeId = 2)
        {
            var model = new PlaceListViewModel();
            model.Places = response.Result;
            model.PageSize = pageSize;
            model.PageNumber = pageNumber;
            model.SortOrder = sortOrder;
            model.SortAscending = sortAscending;
            model.TotalPages = response.TotalPages;
            model.PlaceTypeId = PlaceTypeId;

            PaginationModel pageModel = new PaginationModel();
            pageModel.TotalPages = response.TotalPages;
            pageModel.PageNumber = pageNumber;
            pageModel.PageSize = pageSize;
            pageModel.SortOrder = sortOrder;
            pageModel.SortAscending = sortAscending;
            pageModel.PlaceTypeId = PlaceTypeId;

            model.Pagination = Pagination.CreatePaginationList(pageModel, urlHelper);

            return model;
        }
    }
}
