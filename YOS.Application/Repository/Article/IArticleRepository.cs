using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using YOS.Application.Repository.Base;

namespace YOS.Application.Repository.Article
{
    public interface IArticleRepository : IRepositoryBase<Domain.Domain.Article>
    {
        Task<Domain.Domain.Article> Create(Domain.Domain.Article entity, IFormFile avatar);
    }
}
