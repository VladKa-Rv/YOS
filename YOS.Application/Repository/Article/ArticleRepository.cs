using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

            var articleAvatar = new ArticlePhoto()
            {
                Name = avatarBase64,
                FileName = avatar.FileName,
            };

            entity.ArticlePhotos = new List<ArticlePhoto>
            {
                articleAvatar
            };
            context.Articles.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }
        
        public async Task<Domain.Domain.Article> Edit(Domain.Domain.Article entity, IFormFile avatar)
        {
            var article = await context.Articles
                .Where(x => x.Id == entity.Id)
                .FirstOrDefaultAsync();

            article.Name = entity.Name;
            article.Category = entity.Category;
            article.Description = entity.Description;
            article.ProductCountry = entity.ProductCountry;
            article.Price = entity.Price;

            await context.SaveChangesAsync();
            return entity;
        }


        public async Task<string> Delete(int id)
        {
            var result = await context.Articles
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return "Помилка видалення";
            }
            context.Articles.Remove(result);
            await context.SaveChangesAsync();

            return "Видалено";
        }
    }
}
