﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Repositories.Contracts
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
        Article GetArticleById(int id);
    }
}
