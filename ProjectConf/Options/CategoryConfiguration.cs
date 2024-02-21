using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConf.Options
{
    public  class CategoryConfiguration:BaseEntityConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Kategoriler");
        }
    }
}
