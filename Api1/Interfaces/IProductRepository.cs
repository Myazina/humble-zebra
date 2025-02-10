using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Dtos.Product;
using Api1.Helpers;
using Api1.Models;

namespace Api1.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(QueryObject query);
        Task<Product?> GetByIdAsync(int id);
        //Task<Product?> GetByNameAsync(string Name);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(int id, UpdateProductRequestDto productDto);
        Task<Product?> DeleteAsync(int id);
        Task<bool> ProductExists(int id);
    }
}