using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using YOS.Application.AutoMapper.Models;

namespace YOS.Application.ModelValidation
{
    public class ArticleModelValidator : AbstractValidator<ArticleModel>
    {
        public ArticleModelValidator()
        {
            RuleFor(rule => rule.Name)
                .NotEmpty();
            RuleFor(rule => rule.Category)
                .NotEmpty();
            RuleFor(rule => rule.Description)
                .NotEmpty();
            RuleFor(rule => rule.Price)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
