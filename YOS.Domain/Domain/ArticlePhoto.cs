using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOS.Domain.Domain
{
    public class ArticlePhoto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FileName { get; set; }
        public int ArticleId { get; set; }
        public Article? Article { get; set; }

    }
}
