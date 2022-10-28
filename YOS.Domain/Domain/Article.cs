using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YOS.Domain.Domain
{
    public class Article
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int Price { get; set; }
        public List<ArticlePhoto>?  ArticlePhotos { get; set; }
    }
}
