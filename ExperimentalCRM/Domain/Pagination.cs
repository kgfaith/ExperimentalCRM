using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExperimentalCMS.ViewModels;

namespace ExperimentalCMS.Web.BackEnd.Domain
{
    internal static class Pagination
    {
        private static readonly int[] PageSizes = new[] { 10, 25, 50, 100 };

        internal static IEnumerable<SelectListItem> CreatePageSizeSelectListUsing(int selectedPageSize)
        {
            return PageSizes
                .Select(size => new SelectListItem
                {
                    Text = size.ToString(),
                    Value = size.ToString(),
                    Selected = size == selectedPageSize
                });
        }

        internal static IEnumerable<SelectListItem> CreatePageSizeSelectListUsing(int selectedPageSize, int totalResult)
        {
            var pageSizes = PageSizes;
            var list = new List<int>();
            list.Add(pageSizes[0]);
            for (int i = 1; i < pageSizes.Length; i++)
            {
                if (pageSizes[i] < totalResult)
                    list.Add(pageSizes[i]);
            }

            var pageSizeList = list.Select(size => new SelectListItem
            {
                Text = size.ToString(),
                Value = size.ToString(),
                Selected = size == selectedPageSize
            });
            return pageSizeList;
        }

        internal static IEnumerable<PaginationItemModel> CreatePaginationList(PaginationModel model, UrlHelper url)
        {
            if (url == null)
            {
                return null;
            }

            var list = new List<PaginationItemModel>();

            const int defaultPagesToShow = 5;

            var pagesToShow = model.TotalPages < defaultPagesToShow ? model.TotalPages : defaultPagesToShow;
            var showPaginationControls = model.TotalPages > 1;

            var showNext = model.PageNumber + 1 <= model.TotalPages;
            var nextPageSetting = new { PageNumber = model.PageNumber + 1, model.PageSize, model.SortOrder, model.SortAscending };

            var showPrevious = model.PageNumber > 1;
            var previousPageSetting = new { PageNumber = model.PageNumber - 1, model.PageSize, model.SortOrder, model.SortAscending };

            var showSkipForwards = model.PageNumber + (pagesToShow / 2) < model.TotalPages;

            int skipForwardsPageNumber = model.PageNumber + pagesToShow >= model.TotalPages ? model.TotalPages : model.PageNumber + pagesToShow;

            var skipForwardsPageSetting = new { PageNumber = skipForwardsPageNumber, model.PageSize,model.SortOrder, model.SortAscending };

            var showSkipBackwards = model.PageNumber > (pagesToShow / 2) + 1;

            int skipBackwardsPageNumber = model.PageNumber - pagesToShow <= 0 ? 1 : model.PageNumber - pagesToShow;

            var skipBackwardsPageSetting = new { PageNumber = skipBackwardsPageNumber, model.PageSize, model.SortOrder, model.SortAscending };


            var firstPage = new { PageNumber = 1, model.PageSize, model.SortOrder, model.SortAscending };

            var lastPage = new { PageNumber = model.TotalPages, model.PageSize, model.SortOrder, model.SortAscending };

            var startPage = model.TotalPages - model.PageNumber < pagesToShow / 2M
                ? model.TotalPages - pagesToShow + 1
                : model.PageNumber - (pagesToShow / 2) < 1 ? 1 : model.PageNumber - (pagesToShow / 2);
            var endPage = model.PageNumber <= (pagesToShow / 2)
                ? pagesToShow
                : model.PageNumber + (pagesToShow / 2) > model.TotalPages ? model.TotalPages : model.PageNumber + (pagesToShow / 2);

            if (showPaginationControls)
            {
                if (model.PageNumber > 1)
                    list.Add(new PaginationItemModel { DataPage = "1", IsSelected = false, Text = "&laquo;", Url = url.Action(model.LinkAction, model.LinkController, firstPage) });

                if (showSkipBackwards)
                {
                    list.Add(new PaginationItemModel { DataPage = skipBackwardsPageNumber.ToString(), IsSelected = false, Text = "...", Url = url.Action(model.LinkAction, model.LinkController, skipBackwardsPageSetting) });
                }

                for (int i = startPage; i <= endPage; i++)
                {
                    list.Add(new PaginationItemModel { DataPage = i.ToString(), IsSelected = (i == model.PageNumber), Text = i.ToString(), Url = url.Action(model.LinkAction, model.LinkController, new { PageNumber = i, PageSize = model.PageSize, SortOrder = model.SortOrder, SortAscending = model.SortAscending }) });
                }

                if (showSkipForwards)
                {
                    list.Add(new PaginationItemModel { DataPage = skipForwardsPageNumber.ToString(), IsSelected = false, Text = "...", Url = url.Action(model.LinkAction, model.LinkController, skipForwardsPageSetting) });
                }

                if (model.PageNumber < model.TotalPages)
                    list.Add(new PaginationItemModel { DataPage = model.TotalPages.ToString(), IsSelected = false, Text = "&raquo;", Url = url.Action(model.LinkAction, model.LinkController, lastPage) });

                if (showPrevious)
                {
                    list.Add(new PaginationItemModel { ListClass = "prev", DataPage = "previous", IsSelected = false, Text = "Previous", Url = url.Action(model.LinkAction, model.LinkController, previousPageSetting) });
                }

                if (showNext)
                {
                    list.Add(new PaginationItemModel { ListClass = "next", DataPage = "next", IsSelected = false, Text = "Next", Url = url.Action(model.LinkAction, model.LinkController, nextPageSetting) });
                }


            }

            return list;
        }
    }
}