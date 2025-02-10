using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Data;
using Api1.Dtos.Product;
using Api1.Helpers;
using Api1.Interfaces;
using Api1.Models;
using Microsoft.EntityFrameworkCore;

namespace Api1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiContext _context;
        public ProductRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }
        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (productModel == null)
            {
                return null;
            }

            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }
        public async Task<List<Product>> GetAllAsync(QueryObject query)
        {        
            var products = _context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                products = products.Where(s => s.Name.Contains(query.Name));
            }
            if (!string.IsNullOrWhiteSpace(query.Description))
            {
                products = products.Where(s => s.Description.Contains(query.Description));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    products = query.IsDecsending ? products.OrderByDescending(s => s.Description) : products.OrderBy(s => s.Description);
                }
            }

             var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }        
        public Task<bool> ProductExists(int id)
        {
            return  _context.Products.AnyAsync(s => s.Id == id);
        }
        public async Task<Product?> UpdateAsync(int id, UpdateProductRequestDto productDto)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.Name = productDto.Name;
            existingProduct.ImgUrl = productDto.ImgUrl;
            existingProduct.Price = productDto.Price;
            existingProduct.Description = productDto.Description;

            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}