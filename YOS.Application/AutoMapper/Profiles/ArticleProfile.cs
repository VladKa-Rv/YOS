using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using YOS.Application.AutoMapper.Models;
using YOS.Domain.Domain;

namespace YOS.Application.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleModel>().ReverseMap();
            CreateMap<ArticlePhoto, ArticlePhotoModel>().ReverseMap();
        }
    }
}
