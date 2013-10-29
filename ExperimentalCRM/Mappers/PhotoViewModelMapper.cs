using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExperimentalCMS.Model;
using ExperimentalCMS.ViewModels;

namespace ExperimentalCMS.Web.BackEnd.Mappers
{
    internal class PhotoViewModelMapper
    {
        internal PhotoViewModelMapper()
        {
        }

        internal Picture Map(PhotoViewModel viewModel)
        {
            var picture = new Picture
                                {
                                    FileName = viewModel.FileName,
                                    OwnerName = viewModel.OwnerName,
                                    Title = viewModel.Title,
                                    Description = viewModel.Description,
                                    PictureSourceId = 2
                                };
            return picture;
        }
    }
}