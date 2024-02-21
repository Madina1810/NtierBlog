using Entities.Models;
using ProjectConf.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ContextClasses
{
    public  class MyContext:DbContext
    {
        public MyContext():base("MyConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());    
            modelBuilder.Configurations.Add(new ArticleTagConfiguration());
            modelBuilder.Configurations.Add(new AutorProfileConfiguration()); 
        }

        public DbSet<Article>Articles { get; set; }
        public DbSet<ArticleTag>ArticleTags { get; set; }   
        public DbSet<Author>Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags{ get; set; }

        public DbSet<AuthorProfile> AuthorProfiles { get; set; }
       

    }
}
