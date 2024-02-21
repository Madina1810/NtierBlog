using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public  class AuthorProfile:BaseEntity
    {
        public string FirstName  { get; set; }
        public string LastName { get; set; }

        public virtual Author Author { get; set; }
    }
}
