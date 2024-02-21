using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConf.Options
{
    public  class TagConfiguration:BaseEntityConfiguration<Tag>
    {
        public TagConfiguration()
        {
            ToTable("Etiketler");
        }
    }
}
