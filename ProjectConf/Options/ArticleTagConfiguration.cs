using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConf.Options
{
    public  class ArticleTagConfiguration:BaseEntityConfiguration<ArticleTag>
    {
        public ArticleTagConfiguration()
        {
            ToTable("Makale Etiketleri");


            Ignore(x => x.ID);
            HasKey(x => new
            {
                x.ArticleID,
                x.TagID
            });
        }
    }
}
