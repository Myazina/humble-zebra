using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Data;
using Api1.Dtos.Product;
using Api1.Mappers;
using Api1.Interfaces;
using Api1.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api1.Controllers
{
    [Route("Api1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IProductRepository _productRepo;
        public ProductController(ApiContext context, IProductRepository productRepo)
        {
            _productRepo = productRepo;
            _context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll([FromQuery] QueryObject query)
        {
          var products = await _productRepo.GetAllAsync(query);
          var productDto = products.Select(s => s.ToProductDto());

          return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
          var products = await _productRepo.GetByIdAsync(id);
          if (products == null)
          {
             return NotFound();
          } 
          return Ok(products.ToProductDto());
        }
         [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDto productDto)
        {
            var productModel = productDto.ToProductFromCreateDTO();
            await _productRepo.CreateAsync(productModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, productModel.ToProductDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequestDto updateDto)
        {
            var productModel = await _productRepo.UpdateAsync(id, updateDto);
            if (productModel == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();
            return Ok(productModel.ToProductDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var productModel = await _productRepo.DeleteAsync(id);

            if (productModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}