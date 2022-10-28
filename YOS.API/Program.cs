using FluentValidation;
using Microsoft.EntityFrameworkCore;
using YOS.Application.ModelValidation;
using YOS.Application.Repository.Article;
using YOS.Domain.Context;
using YOS.Domain.Domain;

namespace YOS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IValidator<Article>, ArticleAbstractValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<ArticleAbstractValidator>();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "DefaultCors",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000");
                    });
            });

            builder.Services.AddTransient<IArticleRepository, ArticleRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseCors("DefaultCors");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}