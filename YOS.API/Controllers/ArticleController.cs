using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOS.Application.AutoMapper.Models;
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
        private readonly IMapper mapper;
        private readonly IValidator<ArticleModel> validator;
        private readonly IArticleRepository articleRepository;

        public ArticleController(AppDbContext context, IValidator<ArticleModel> validator, IArticleRepository articleRepository, IMapper mapper)
        {
            this.articleRepository = articleRepository;
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArticleModel>>> GetArticles(bool? IncludePhoto)
        {
            var articles = new List<Article>();

            if (IncludePhoto == false)
            {
                articles = await context.Articles
                    .ToListAsync();
            }
            else
            {
                articles = await context.Articles
                    .Include(x => x.ArticlePhotos)
                    .ToListAsync();
            }

            var result = mapper.Map<List<ArticleModel>>(articles);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            var article = await context.Articles
                .Include(x => x.ArticlePhotos)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var model = mapper.Map<ArticleModel>(article);

            return Ok(model);
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromQuery] ArticleModel model, [FromForm] IFormFile avatar)
        {
            var validateResult = await validator.ValidateAsync(model);

            if (!validateResult.IsValid)
            {
                return new BadRequestObjectResult(new
                {
                    data = validateResult.Errors,
                });
            }
            var article = mapper.Map<Article>(model);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] ArticleModel model, [FromForm] IFormFile avatar)
        {
            var validateResult = await validator.ValidateAsync(model);
            if (!validateResult.IsValid)
            {
                return new BadRequestObjectResult(new
                {
                    data = validateResult.Errors,
                });
            }

            var article = mapper.Map<Article>(model);
            var result = await articleRepository.Create(article, avatar);

            return Ok("Article created ");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await articleRepository.Delete(id);

            return Ok(result);
        }

    }
}
