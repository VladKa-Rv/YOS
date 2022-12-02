using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOS.Domain.Domain;

namespace YOS.Application.AutoMapper.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? ProductCountry { get; set; }
        public int Price { get; set; }
        public int Count { get; set; } = 1;
        public string? ShortDescription { get; set; }
        public List<ArticlePhotoModel>? ArticlePhotos { get; set; }
    }
}
