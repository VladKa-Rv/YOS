using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace YOS.Domain.Domain
{
    public class Article
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? ProductCountry { get; set; }
        public int Price { get; set; }
        public string? ShortDescription { get; set; }
        public int Count { get; set; } = 1;
        public List<ArticlePhoto>?  ArticlePhotos { get; set; }
    }
}
