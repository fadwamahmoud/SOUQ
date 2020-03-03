using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Souq2.Models
{
    public class Brand
    {
        public Brand()
        {
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}