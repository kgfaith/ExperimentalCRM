using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Domain.Utility;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories;

namespace ExperimentalCMS.Domain.Managers
{
    public class ArticleManager : IArticleManager
    {
        private IUnitOfWork _uOW;

        public ArticleManager(IUnitOfWork uow)
        {
            _uOW = uow;
        }

        public DomainResponse<Article> CreateNewArticle(Article newArticle)
        {
            var response = new DomainResponse<Article>();

            try
            {
                newArticle = _uOW.ArticleRepo.Insert(newArticle);
                _uOW.Save();
            }
            catch (Exception ex)
            {
                return response.ReturnFailResponse(new[] { ex.Message }
                       , "There is an error trying to update data"
                       , null);
            }

            if (newArticle.ArticleId > 0)
            {

                return response.ReturnSuccessResponse(newArticle
                        , new[] { "Admin data has been successfully updated." }
                        , "Admin data has been successfully updated.");
            }
            else
            {
                return response.ReturnFailResponse(new[] { "Error occur while trying to insert new article" }
                       , "There is an error trying to save data"
                       , null);
            }
        }

        public DomainResponse<BooleanResult> EditArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAllArticleList()
        {
            throw new NotImplementedException();
        }

        public DomainResponse<Article> GetArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
