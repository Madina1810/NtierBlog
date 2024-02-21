using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConf.Options
{
   public  class AutorProfileConfiguration:BaseEntityConfiguration<AuthorProfile>
    {
        public AutorProfileConfiguration()
        {
            ToTable("Yazar Profilleri");
        }
    }
}
