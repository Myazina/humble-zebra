using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Dtos.Product
{
        public class CreateProductRequestDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Name cannot be over 20 over characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "ImgUrl cannot be over 30 over characters")]
        public string ImgUrl { get; set; } = string.Empty;
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
       
    }
}