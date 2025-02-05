using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Models
{
    [Table("Products")]
    public class Product
    {
        //[required]
        public int Id { get; set; }
        //[required]
        public string Name { get; set; } = string.Empty;
        //[required]
        public string ImgUrl { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        //[required]
        public decimal Price { get; set; }      
        public string Description { get; set; } = string.Empty;      

    }
}