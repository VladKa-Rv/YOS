using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using YOS.Domain.Domain;

namespace YOS.Application.ModelValidation
{
    public class ArticleAbstractValidator : AbstractValidator<Article>
    {
        public ArticleAbstractValidator()
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
