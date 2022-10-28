using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using YOS.Application.Base64Service;
using YOS.Application.Repository.Base;
using YOS.Domain.Context;
using YOS.Domain.Domain;

namespace YOS.Application.Repository.Article
{
    public class ArticleRepository : RepositoryBase<Domain.Domain.Article>, IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Domain.Domain.Article> Create(Domain.Domain.Article entity, IFormFile avatar)
        {
            var avatarBase64 = await Base64Converter.ToBase64StringAsync(avatar);

            context.Articles.Add(entity);

            var articleAvatar = new ArticlePhoto()
            {
                Name = avatarBase64,
                FileName = avatar.FileName,
                Article = entity,
            };


            context.ArticlePhotos.Add(articleAvatar);

            entity.ArticlePhotos?.Add(articleAvatar);

            

            await context.SaveChangesAsync();

            return entity;
        }

    }
}
