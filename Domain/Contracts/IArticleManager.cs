using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Utility;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Contracts
{
    public interface IArticleManager
    {
        DomainResponse<Article> CreateNewArticle(Article newArticle);
        DomainResponse<BooleanResult> EditArticle(Article article);
        IEnumerable<Article> GetAllArticleList();
        DomainResponse<Article> GetArticleById(int id);
        bool DeleteArticleById(int id);
        void Dispose();
    }
}
