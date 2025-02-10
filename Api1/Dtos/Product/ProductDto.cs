using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Dtos.Product
{
    public class ProductDto
    {     
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }        
        public string Description { get; set; } = string.Empty; 
    
    }
}