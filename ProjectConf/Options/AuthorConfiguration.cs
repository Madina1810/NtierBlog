using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConf.Options
{
    public  class AuthorConfiguration : BaseEntityConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            ToTable("Yazarlar");
            HasOptional(x => x.Profile).WithRequired(x => x.Author);
        }
    }
}
