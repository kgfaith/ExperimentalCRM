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
                                    PictureSourceId = viewModel.SourceId,
                                    ImageUrl = viewModel.ImageUrl
                                };
            return picture;
        }

        internal PhotoViewModel Map(Picture pic)
        {
            var picture = new PhotoViewModel
            {
                PictureId = pic.PictureId.ToString(),
                FileName = pic.FileName,
                OwnerName = pic.OwnerName,
                Title = pic.Title,
                Description = pic.Description,
                SourceId = pic.PictureSourceId,
                ImageUrl = pic.ImageUrl
            };
            return picture;
        }
    }
}