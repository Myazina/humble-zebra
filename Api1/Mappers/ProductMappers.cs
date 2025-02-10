using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Dtos.Product;
using Api1.Models;

namespace Api1.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                ImgUrl = productModel.ImgUrl,
                Price = productModel.Price,
                Description = productModel.Description                
            };
        }
        public static Product ToProductFromCreateDTO(this CreateProductRequestDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                ImgUrl = productDto.ImgUrl,
                Price = productDto.Price,
                Description = productDto.Description                
            };
        }
    }
}