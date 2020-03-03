using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Souq2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float PriceAfterSale { get; set; }
        public string Image { get; set; }

        [ForeignKey("Category")]
        public int FK_CategoryId { get; set; }
        [ForeignKey("Brand")]
        public int FK_BrandId { get; set; }
        [ForeignKey("User")]
        public int FK_UserId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual User User { get; set; }

    }
}