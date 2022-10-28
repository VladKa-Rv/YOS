using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YOS.Domain.Domain;

namespace YOS.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public  DbSet<User> Users { get; set; }
        public  DbSet<Article> Articles { get; set; }
        public  DbSet<ArticlePhoto> ArticlePhotos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public AppDbContext()
        {

        }
    }
}
