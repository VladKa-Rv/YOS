using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOS.Application.ModelValidation;
using YOS.Application.Repository.Article;
using YOS.Domain.Context;
using YOS.Domain.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YOS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IValidator<Article> validator;
        private readonly IArticleRepository articleRepository;

        public ArticleController(AppDbContext context, IValidator<Article> validator, IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
            this.context = context;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetArticles()
        {
            var articles = await context.Articles
                .Include(x => x.ArticlePhotos)
                .ToListAsync();

            return Ok(articles);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var article = await context.Articles
                .Include(x => x.ArticlePhotos)
                .FirstOrDefaultAsync();
            
            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] Article modelArticle, [FromForm] IFormFile avatar)
        {
            var validateResult = await validator.ValidateAsync(modelArticle);
            if (!validateResult.IsValid)
            {
                return new BadRequestObjectResult(new
                {
                    data = validateResult.Errors,
                });
            }
            var result = await articleRepository.Create(modelArticle, avatar);

            return Ok("Article created ");
        }
    }
}
